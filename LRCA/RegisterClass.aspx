<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterClass.aspx.cs" Inherits="LRCA.RegisterClass" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <!-- Meta -->
    <meta name="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="description" content="LRCA: LEAD Rental Certification and Accreditation.">
    <meta name="author" content="LEAD Rental Certification and Accreditation">
    

    <!-- Google Font -->
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css'>
    
    <!-- Bootstrap Core CSS -->
    <link href="CSSFrontEnd/assets_/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">
    
    <!-- Plugins CSS -->
    <link href="CSSFrontEnd/assets_/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="CSSFrontEnd/assets_/plugins/animate-css/animate.min.css" rel="stylesheet" type="text/css">
    <link href="CSSFrontEnd/assets_/plugins/owl-carousel/owl.carousel.css" rel="stylesheet" type="text/css">
    <link href="CSSFrontEnd/assets_/plugins/owl-carousel/owl.theme.css" rel="stylesheet" type="text/css">
    <link href="CSSFrontEnd/assets_/plugins/jquery-magnificPopup/magnific-popup.css" rel="stylesheet" type="text/css">
     <link rel="stylesheet" href="CSSFrontEnd/assets_/plugins/parallax-slider/css/parallax-slider.css">
    <link rel="stylesheet" href="CSSFrontEnd/assets/plugins/layer_slider/css/layerslider.css" type="text/css">
    <!-- Component CSS -->
    <link href="CSSFrontEnd/assets_/css/component/component.css" rel="stylesheet" type="text/css">
    <!--<link href="CSSFrontEnd/assets_/css/component/colors/blue.css" rel="stylesheet" type="text/css">-->
    
    <!-- Main CSS -->
    <link href="CSSFrontEnd/assets_/css/rinjani.css" rel="stylesheet" type="text/css">
    <!--<link href="CSSFrontEnd/assets_/css/colors/blue.css" rel="stylesheet" type="text/css">-->
    
     <script type="text/javascript" src="CSSBackEnd/vendor/jquery/dist/jquery.min.js"></script>
    <script type="text/javascript"  src="CSSBackEnd/scripts/bootstrap-notify.min.js"></script>
    
     <script type="text/javascript">
        function CallNotify(titleIn, msgIn, msgType, URLTo) {
            $.notify({
                // options
                icon: 'glyphicon glyphicon-warning-sign',
                title: titleIn,
                message: msgIn,
                url: '',
                target: '_blank'
            }, {
                // settings
                element: 'body',
                position: null,
                type: msgType,
                allow_dismiss: true,
                newest_on_top: true,
                showProgressbar: false,
                placement: {
                    from: "top",
                    align: "center"
                },
                offset: 0,
                spacing: 10,
                z_index: 1031,
                delay: 13000,
                timer: 10000,
                url_target: '_blank',
                mouse_over: null,
                animate: {
                    enter: 'animated fadeInDown',
                    exit: 'animated fadeOutUp'
                },
                onShow: null,
                onShown: null,
                onClose: null,
                onClosed: null,
                icon_type: 'class',
                template: '<div data-notify="container" width="100%" class="col-xs-12 col-sm-3 alert alert-{0}" role="alert">' +
                    '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                    '<span data-notify="icon"></span> ' +
                    '<span data-notify="title">{1}</span> ' +
                    '<span data-notify="message" nowrap>{2}</span>' +
                    '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                    '</div>' +
                    '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
            });
            if (URLTo != "#")
            {
                setTimeout(function () {
                    $.notifyClose();
                    $(location).attr('href', URLTo)
                }, 4500);
            }
            
        }
    </script>

    <!-- Modernizr JS for IE9 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="CSSFrontEnd/assets_/plugins/modernizr.min.js"></script>
    <![endif]-->
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
  
        <div class="section">
        <div class="section-inner">
         <div class="container section-content">
         <div class="row">
             <br /><br />
                    <div class="col-md-12">
                        <div class="section-title text-center">
                            <h5 class="sub-title">Class Registration</h5>
                            <small>For class Registration you must have an account on LRCA. Please, Register below.</small>
                            <asp:Label ID="lblerror" runat="server" ></asp:Label>
                        </div>
                        <!-- //.section-title -->
                         <div style="float: none; margin: 0 auto; border:thin; border-width:1px; border-color:#ccc;overflow:hidden;" class="col-md-4">
                    <div class="hpanel">
                <div class="panel-body">                        
                    <div class="row">
                    <div class="col-md-8">
                        <div class="form-group">
                            <asp:TextBox ID="txt_FName" placeholder="First Name" runat="server" class="form-control" required></asp:TextBox>
                         </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                            <asp:TextBox ID="txt_LName" placeholder="Last Name" runat="server" class="form-control" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                            <asp:TextBox ID="txt_email" placeholder="Email" runat="server" class="form-control" required></asp:TextBox>
                            </div>
                        </div>
                    </div>                   
                           <asp:Button ID="btnSendRequest" CssClass="btn btn-success btn-block" ValidationGroup="valGroup2" CausesValidation="true" runat="server" OnClick="btnReset" Text="Create Account" /> 
                           
                </div>
            </div>
                </div>
                    </div>
                    <!-- //.col-md-12 -->
                </div>
                <!-- //.row -->
                
                 
                    <!-- //.col-md-12 -->
                
                <!-- //.row -->
             
           
                <!-- //.row -->
            
            <!-- //.section-content -->
             </div>
        </div>
            </div>
   
    </form>
</body>
</html>
