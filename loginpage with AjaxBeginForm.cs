 
Login page with html template with pass data Ajax.BeginForm() Method
//    =================================================================================================================== 

Registration.cs 

public partial class Registration
    {
        public int reg_id { get; set; }
        public string reg_firstname { get; set; }
        public string reg_lastname { get; set; }
        public string reg_email { get; set; }
        public string reg_phone { get; set; }
        public string reg_password { get; set; }
        public string reg_confirmpassword { get; set; }
        public Nullable<int> req_question_id { get; set; }
        public string req_answer { get; set; }
        public string reg_gender { get; set; }
    }

//    =================================================================================================================== 
login.cshtml 
 
 @model RegistrationDiffrentFormat.Models.Registration
 @using (Ajax.BeginForm("login2", "Accounts", new AjaxOptions { OnSuccess = "OnSuccess", OnFailure = "OnFailure" }))
    {
        <div class="limiter">
            <div class="container-login100" style="background-image: url('/Theme/Login/images/bg-01.jpg');">
                <div class="wrap-login100">
                    <form class="login100-form validate-form">
                        <span class="login100-form-logo">
                            <i class="zmdi zmdi-landscape"></i>
                        </span>

                        <span class="login100-form-title p-b-34 p-t-27">
                            Log in
                        </span>

                        <div class="wrap-input100 validate-input" data-validate="Enter username">
                            <input class="input100" type="text" name="reg_email" placeholder="Emai ID">
                            <span class="focus-input100" data-placeholder="&#xf207;"></span>
                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Enter password">
                            <input class="input100" type="password" name="reg_password" placeholder="Password">
                            <span class="focus-input100" data-placeholder="&#xf191;"></span>
                        </div>

                        @*<div class="contact100-form-checkbox">
                                <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
                                <label class="label-checkbox100" for="ckb1">
                                    Remember me
                                </label>
                            </div>*@

                        <div class="container-login100-form-btn">
                            <button class="login100-form-btn" type="submit">
                                Login
                            </button>
                        </div>

                        <div class="text-center p-t-90">
                            <a class="txt1" href="#">
                                Forgot Password?
                            </a>
                        </div>
                    </form>

                </div>
            </div>
        </div>
    }

    <script>
        function OnSuccess(responce) {
            console.log(response)
        }

        function OnFailure(responce) {
            console.log("data not found ")
        }
    </script>






//    ===================================================================================================================
    LoginController.cs

     // Session Login form using Ajax.Beginform

        xallerEntities db = new xallerEntities();
        public ActionResult login2()
        {
            return View();

        }
        [HttpPost]
        public ActionResult login2(Registration objUser)
        {
            if (ModelState.IsValid)
              {
                var obj = db.Registrations.Where(a => a.reg_email.Equals(objUser.reg_email) && a.reg_password.Equals(objUser.reg_password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = objUser.reg_id.ToString();
                    Session["UserEmail"] = objUser.reg_email.ToString();
                    return RedirectToAction("index", "Home");
                }
            }   
            return View(objUser);
        }

        // for Logout Session

         public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("login2", "Accounts");
        }


//    ===================================================================================================================
        _Layout.cshtml

        <div> 
             @if (Session["UserEmail"] != null)
             {
                 @Session["UserEmail"].ToString()
             } 
        </div>


        
//    ===================================================================================================================

Note  :  1.Button must be submit types 
         2.id and name attribuutes must be match the table fromat