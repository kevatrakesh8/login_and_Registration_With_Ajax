 @model RegistrationDiffrentFormat.Models.Registration
@{
    ViewBag.Title = "RegistrationForm3";
    Layout = "~/Views/Shared/_RegisterLayout.cshtml"; 
}

@using (Ajax.BeginForm("RegistrationForm3", "Accounts", new AjaxOptions { OnSuccess = "OnSuccess", OnFailure = "OnFailure" }))
{

    <div class="container register">
        <div class="row">
            <div class="col-md-3 register-left">
                <img src="https://image.ibb.co/n7oTvU/logo_white.png" alt="" />
                <h3>Grant Program Registration</h3>
                <p>Welcome to the Tech for Web development Application</p>
                <input type="submit" name="" value="Login" onclick="login()" /><br />
            </div>
            <div class="col-md-9 register-right">
                <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Employee</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Hirer</a>
                    </li>
                </ul>
                <form id="frm-registration" name="frm-registration">
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                            <h3 class="register-heading">Student Registration Form</h3>

                            <div class="row register-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.reg_firstname, new { htmlAttributes = new { @class = "form-control", placeholder = "First Name" } })
                                    </div>
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.reg_lastname, new { htmlAttributes = new { @class = "form-control", placeholder = "Last Name" } })
                                     </div>
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.reg_password, new { htmlAttributes = new { @class = "form-control", placeholder = "Password" } })
                                      </div>
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.reg_confirmpassword, new { htmlAttributes = new { @class = "form-control", placeholder = "Confirm Password" } })
                                     </div>
                                    <div class="form-group">
                                        <div class="maxl" name="reg_gender">
                                            <label class="radio inline">
                                                @Html.RadioButtonFor(model => Model.reg_gender, "Male", new { htmlAttributes = new { @class = "form-control", placeholder = "Last Name", name = "gender" } })
                                                 <span> Male </span>
                                            </label>
                                            <label class="radio inline">
                                                @Html.RadioButtonFor(model => model.reg_gender, "Female", new { htmlAttributes = new { @class = "form-control", placeholder = "Last Name", name = "gender" } })
                                                 <span>Female </span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.reg_email, new { htmlAttributes = new { @class = "form-control", placeholder = "Your Email" } })
                                     </div>
                                    <div class="form-group">
                                        @Html.EditorFor(modle => Model.reg_phone, new { htmlattributes = new { @class = "form-control", placeholder = "Your Phone" } })
                                     </div>
                                    <div class="form-group">
                                        @Html.DropDownListFor(model => model.req_question_id, ViewBag.questionlist as SelectList, "-- Select question __", new { @class = "form-control" })
                                        
                                    </div>
                                    <div class="form-group">
                                        @Html.EditorFor(model => model.req_answer, new { htmlattributes = new { @class = "form-control", placeholder = "Enter Your Answer" } })
                                     </div>
                                     <input type="submit" class="btnRegister" value="Register" @*onclick="Registration()"*@ />
                                </div>
                            </div>
                        </div>
                    </div>
                </form>


                <div id="ajaxphp-results"></div>
            </div>
        </div>
    </div>
} 

@section scripts{
    <script src="~/Scripts/jquery-3.3.1.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script>
        function OnSuccess(responce) {
            console.log(response)
        }

        function OnFailure(responce) {
            console.log("data not found ")
        }
                    
    </script>

} 
  
//============================================================================================================
AccountController.cs 


public ActionResult RegistrationForm3()
        {
            var questions = db.registration_question.ToList();
            ViewBag.questionlist = new SelectList(questions, "question_id", "question_ask");
            return View();
        }
        [HttpPost]
        public JsonResult RegistrationForm3(Registration registration)
        {
            return Json("pass data sucessfull", JsonRequestBehavior.AllowGet);
        }



//==============================================================================================================
// notes :
//         1. We must have to two table registration and registration_question for dropdown)
//         1. input type="Submit"     must be this format
//         2. @using (Ajax.BeginForm("RegistrationForm3", "Accounts", new AjaxOptions { OnSuccess = "OnSuccess", OnFailure = "OnFailure" }))
//              {
//              }
//     <script>
//        function OnSuccess(responce)
//           {
//             console.log(response)
//           }

//         function OnFailure(responce) 
//          {
//             console.log("data not found ")
//          }
//     </script>