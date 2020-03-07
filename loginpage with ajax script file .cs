//=============================================================================================================


login.cshtml
 
@model RegistrationDiffrentFormat.Models.Registration
@{
    Layout = null;
}

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login V3</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="~/Theme/Login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/css/util.css">
    <link rel="stylesheet" type="text/css" href="~/Theme/Login/css/main.css">
    <!--===============================================================================================-->

    <link href="~/Theme/Login/vendor/select2/select2.css" rel="stylesheet" />
</head>

<body>


    <div class="limiter">
        <div class="container-login100" style="background-image: url('/Theme/Login/images/bg-01.jpg');">
            <div class="wrap-login100">
                <form class="login100-form validate-form" id="frm-registration">
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
                        <button class="login100-form-btn" type="submit" onclick="Registration()">
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




    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/bootstrap/js/popper.js"></script>
    <script src="~/Theme/Login/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/daterangepicker/moment.min.js"></script>
    <script src="~/Theme/Login/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="~/Theme/Login/js/main.js"></script>
    <script>

        var status = null;

        function Registration()
        {
            var data = $("#frm-registration").serialize();
            var mydata = data;

            $.ajax({
                type: 'post',
                url: '/Accounts/login3',
                data: data,
                dataType: 'JSON',
                success: function (data)
                {
                    status = data.status
                    if (status == 1) {
                        window.location.href = '@Url.Action("Index","Home")';
                    }
                    else if (status == 3)
                    {
                        $('#err').hide().html("User name and password do not blank").fadeIn('slow');
                    }
                }
            });
        }
    </script>

</body>
</html>>

//=============================================================================================================

AccountController.cs 

  //without mvc ajax({ }) pass the data 
        public ActionResult login3()
        {
            return View();

        }
        [HttpPost]
        public ActionResult login3(Registration model)
        {
            string myuser = model.reg_email;
            string pass = model.reg_password;

            using (db)
            {
                string status;
                var usr = (from e in db.Registrations where e.reg_email == myuser && e.reg_password == pass select e).FirstOrDefault();
                //select * fAjaxloginrom login_tbl where user_username = user and passw
                if (myuser != null)
                {
                    Session["MyUser"] = usr.reg_email.ToString();
                    status = "1";
                }
                else
                {
                    status = "3";
                }
                return new JsonResult { Data = new { status = status } };
            }
      

        }
        public ActionResult login3Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Mylogin", "Login");
        }



//=============================================================================================================
  _Layout.cshtml
   @if (Session["MyUser"] != null)
     </li>
        {
            @Session["MyUser"].ToString() 
        }
      </li>


      