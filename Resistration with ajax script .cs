
Registration from with the help of ajax.
//============================================================================== 
@{
    ViewBag.Title = "RegistrationForm1";
    Layout = "~/Views/Shared/_RegisterLayout.cshtml";



}

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

                                    <input type="text" class="form-control" placeholder="First Name *" value="" id="reg_firstname" name="reg_firstname" />
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Last Name *" value="" id="reg_lastname" name="reg_lastname" />
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" placeholder="Password *" value="" id="reg_password" name="reg_password" />
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" placeholder="Confirm Password *" value="" id="reg_confirmpassword" name="reg_confirmpassword" />
                                </div>
                                <div class="form-group">
                                    <div class="maxl" >
                                        <label class="radio inline">
                                            <input type="radio" name="reg_gender" value="male">
                                            <span> Male </span>
                                        </label>
                                        <label class="radio inline">
                                            <input type="radio" name="reg_gender" value="female">
                                            <span>Female </span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input type="email" class="form-control" placeholder="Your Email *" value="" id="reg_email" name="reg_email" />
                                </div>
                                <div class="form-group">
                                    <input type="text" minlength="10" maxlength="10" name="reg_phone" class="form-control" placeholder="Your Phone *" value="" id="reg_phone" />
                                </div>
                                <div class="form-group" >
                                    <select class="form-control" name="req_question_id">
                                        <option class="hidden" selected disabled>Please select your Sequrity Question</option>
                                        <option value="3">What is your Birthdate?</option>
                                        <option value="2">What is Your old Phone Number</option>
                                        <option value="1">What is your Pet Name?</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Enter Your Answer *" value="" id="req_answer" name="req_answer" />
                                </div>
                                <input type="button" class="btnRegister" value="Register" onclick="Registration()" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
            
            <div id="ajaxphp-results"></div>
        </div>
    </div>
</div>


@section scripts{
    <script src="~/Scripts/jquery-3.3.1.js"></script>
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    <script>

        var status = null;

        function Registration()
        {
            var data = $("#frm-registration").serialize();
            var mydata = data;

            $.ajax({
                type: 'post',
                url: '/Accounts/RegistrationForm1',
                data: data,
                dataType: 'JSON',
                success: function (data) {
                console.log(data);
	            //called when successful
	            //$('#ajaxphp-results').html("<h1>Data Added</h1>");
                },
                error: function(e) {
	            //called when there is an error
	            //console.log(e.message);
                }
            });
        }
    </script>

}


@*notes :
    1. Pass the data view to controller with the help of ajax html file.
    2. cheackbox and dropdown should be  pass attributes of (name="").*@ 
