using AutoMapper;
using ConctactInfoCRUDDemo.Helpers;
using ConctactInfoCRUDDemo.Models;
using ContactInfo.BL.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ConctactInfoCRUDDemo.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientBL _patientBL;
        public PatientController(IPatientBL patientBL)
        {
            _patientBL = patientBL;
            EmailHelper.Init(EmailHelper.EMAIL_SENDER, EmailHelper.EMAIL_CREDENTIALS, EmailHelper.SMTP_CLIENT);
        }

        [HttpPost]
        public PatientResponse AddPatient([FromBody]PatientDetailsModel patientDetailsModel)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                if (!ModelState.IsValid)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    patientResponse.Message = "Invalid data";
                    return patientResponse;
                }

                bool isEmailExists = ValidateEmail(patientDetailsModel.Email);
                if (isEmailExists)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    patientResponse.Message = "Email already exists";
                    return patientResponse;
                }

                int coordinatingPersonId = 0;

                if (patientDetailsModel.CoordinatingPerson != null)
                {
                    var coordinatingPerson = Mapper.Map<CoordinatingPersonModel, ContactInfo.DBEntities.Entities.CoordinatingPerson>(patientDetailsModel.CoordinatingPerson);

                    coordinatingPersonId = _patientBL.AddCoordinatingPerson(coordinatingPerson);
                    patientDetailsModel.CoordinatingPerson.CoordinatingPersonId = coordinatingPersonId;
                }
                var patientDetails = Mapper.Map<PatientDetailsModel, ContactInfo.DBEntities.Entities.PatientDetail>(patientDetailsModel);

                if(coordinatingPersonId > 0)
                    patientDetails.CoordinatingPersonId = coordinatingPersonId;

                var patientModel = Mapper.Map<ContactInfo.DBEntities.Entities.PatientDetail, PatientDetailsModel > (_patientBL.AddPatient(patientDetails));

                patientModel.CoordinatingPerson = patientDetailsModel.CoordinatingPerson;

                if (patientModel.PatientId> 0)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "Patient added successfully";
                    patientResponse.Data = patientModel;

                    EmailModel emailModel = new EmailModel();
                    emailModel.Recipient = "";
                    emailModel.Subject = patientModel.Category + " Case Verification";
                    emailModel.Message = "test";
                     
                    if( patientModel.IsPoliceVerificationRequired== true)
                    {
                        bool isMailSent = EmailHelper.SendEMail(emailModel);
                    }
                }
                else
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    patientResponse.Message = "Error while adding";
                }

                return patientResponse;
            }
            catch (Exception ex)
            {
                patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                patientResponse.Message = "Error while adding";

                return patientResponse;
            }
        }

        private bool ValidateEmail(string email)
        {
            return _patientBL.GetAllPatientDetails().Any(u => u.Email.ToLower() == email.ToLower());
        }

        [HttpPost]
        public PatientResponse GetPatient([FromBody]PatientDetailsModel patientDetailsModel)
        
        {
            PatientResponse patientResponse = new PatientResponse();

            try
            {
                var patientList = _patientBL.GetAllPatientDetails();

                var patientListModel = Mapper.Map<IList<ContactInfo.DBEntities.Entities.PatientDetail>, IList<PatientDetailsModel>>(patientList);

                if (!(string.IsNullOrEmpty(patientDetailsModel.PatientName) && string.IsNullOrEmpty(patientDetailsModel.Email) && string.IsNullOrEmpty(patientDetailsModel.PatientName)))
                {
                    bool isEmail = Regex.IsMatch(patientDetailsModel.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    bool isMobileNumber = Regex.IsMatch(patientDetailsModel.MobileNumber, @"^\d{10}$");

                    if((!string.IsNullOrEmpty(patientDetailsModel.Email) && !isEmail) ||
                       (!string.IsNullOrEmpty(patientDetailsModel.MobileNumber) && !isMobileNumber))
                    {
                        patientResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                        patientResponse.Message = "Invalid data";
                        return patientResponse;
                    }

                    if(!string.IsNullOrEmpty(patientDetailsModel.Email))
                    {
                        patientListModel = patientListModel.Where(p => p.Email.ToLower() == patientDetailsModel.Email.ToLower()).ToList();
                    }
                    if (!string.IsNullOrEmpty(patientDetailsModel.MobileNumber))
                    {
                        patientListModel = patientListModel.Where(p => p.MobileNumber == patientDetailsModel.MobileNumber).ToList();
                    }
                    if (!string.IsNullOrEmpty(patientDetailsModel.PatientName))
                    {
                        patientListModel = patientListModel.Where(p => p.PatientName.ToLower() == patientDetailsModel.PatientName.ToLower()).ToList();
                    }
                }

                if (patientListModel.Count() > 0)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "Patient Details Fetched Successfully";
                    patientResponse.Data = patientListModel;
                }
                else
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "No patient found";
                    patientResponse.Data = patientListModel;
                }

                return patientResponse;
            }
            catch (Exception ex)
            {
                patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                patientResponse.Message = "Error while fetching";

                return patientResponse;
            }
        }

        [HttpGet]
        public PatientResponse GetMedicineDetails([FromUri]bool isDelivered)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                var medicineList = _patientBL.GetMedicineDetails(isDelivered);
                if (medicineList.Count() > 0)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "Medicine Details Fetched Successfully";
                    patientResponse.Data = medicineList;
                }
                else
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "No records found";
 
                }

                return patientResponse;
            }
            catch (Exception ex)
            {
                patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                patientResponse.Message = "Error while fetching medicine details";

                return patientResponse;
            }
        }

        [HttpPost]
        public PatientResponse UpdateMedicineStatus([FromBody] PrescriptionListModel prescriptionListModel)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                var prescription = Mapper.Map<List<PrescriptionModel>, List<ContactInfo.DBEntities.Entities.Prescription>>(prescriptionListModel.PrescriptionData);

                var data = _patientBL.UpdateMedicineStatus(prescription);

               if(data.Count() > 0)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "Medicine status updated successfully";
                    patientResponse.Data = data;
                }
               else
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    patientResponse.Message = "Issue in updating medicine status";
                }

                return patientResponse;
            }
            catch (Exception)
            {
                patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                patientResponse.Message = "Issue in updating medicine status";

                return patientResponse;
            }
        }
        
        [HttpPost]
        public PatientResponse AddPatientPoliceCommunicationDetails([FromBody] PatientPoliceCommunicationModel patientPoliceCommunicationModel)
        {
            PatientResponse patientResponse = new PatientResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.BadRequest);
                    patientResponse.Message = "Invalid data";
                    return patientResponse;
                }

                var patientPoliceCommunicationDetails = Mapper.Map<PatientPoliceCommunicationModel, ContactInfo.DBEntities.Entities.PatientPoliceCommunication>(patientPoliceCommunicationModel);

                //var data = _patientBL.AddPatientPoliceCommunicationDetails(patientPoliceCommunicationDetails);

                var data = Mapper.Map<ContactInfo.DBEntities.Entities.PatientPoliceCommunication, PatientPoliceCommunicationModel>(_patientBL.AddPatientPoliceCommunicationDetails(patientPoliceCommunicationDetails));

                if (data.PatientPoliceCommunicationId > 0)
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.OK);
                    patientResponse.Message = "Patient Police Communication added successfully";
                    patientResponse.Data = data;

                }
                else
                {
                    patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    patientResponse.Message = "Error while adding";
                }

                return patientResponse;
            }
            catch (Exception ex)
            {
                patientResponse.Status = Convert.ToInt32(HttpStatusCode.InternalServerError);
                patientResponse.Message = "Error while adding";

                return patientResponse;
            }
        }

    }
}
