<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="LRCA.ResetPassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]>      <html class="no-js"> <!--<![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>MD Dept of Environment: LEAD Rental Certification and Accreditation</title>

    <!-- Meta -->
    <meta name="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="description" content="LRCA: LEAD Rental Certification and Accreditation.">
    <meta name="author" content="LEAD Rental Certification and Accreditation">
    

    <!-- Google Font -->
    <link href='https://fonts.googleapis.com/css?family=Raleway:400,700' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css'>
    
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
    <link href="CSSFrontEnd/assets_/css/gridOutside.css" rel="stylesheet" />

    
    <!--<link href="CSSFrontEnd/assets_/css/colors/blue.css" rel="stylesheet" type="text/css">-->
    
    <!-- Modernizr JS for IE9 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="CSSFrontEnd/assets_/plugins/modernizr.min.js"></script>
    <![endif]-->
  
</head>
<!-- The #page-top ID is part of the scrolling feature - the data-spy and data-target are part of the built-in Bootstrap scrollspy function -->
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top" data-offset="51">
   
    <!--[if lt IE 8]>
        <p class="browsehappy">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
    <![endif]-->    
    
    <!-- Begin Page Loader -->
    <div id="page-loader">
        <div class="preload">
            <img src="CSSFrontEnd/assets_/img/preloader.gif" alt="Loading"/>
        </div>
        <!-- //.preload -->
    </div>
    <!-- //End Page Loader -->
    
    

     


    <!-- Begin Navbar -->
    <nav id="navigation" class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-rj-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                
                <a class="navbar-brand" href="#intro">
                            <img src="CSSFrontEnd/assets/img/smallLogo_new.gif" class="img-responsive" style="width:100%;" />

                </a>
            </div>
            <!-- //.navbar-header -->
            
            <div class="navbar-collapse collapse navbar-rj-collapse">
                 <ul class="nav navbar-nav navbar-right">
                    
                    <li >
                        <a  href="default.aspx#intro">Home</a>
                    </li>
                    
                    <li >
                        <a href="default.aspx#our-main-skills">Courses</a>
                    </li>
                   
                    <li >
                        <a href="default.aspx#who-we-are">About</a>
                    </li>

                     <li >
                        <a href="default.aspx#FAQ">FAQ</a>
                    </li>
                    
                     <li >
                        <a href="default.aspx#login" > Login</a>
                    </li>
                </ul>
            </div>
            <!-- //.navbar-collapse -->
        </div>
        <!-- //.container -->
    </nav>
    <form id="form1" runat="server" defaultbutton="btn_signin">
    <section id="login" class="section">
    <div class="section-inner">
         <div class="container section-content">
         <div class="row">
                    <div class="col-md-12">
                        <div class="section-title text-center">
                            <h3 class="main-title">Reset Password</h3>
                            <h4 class="sub-title">Create a new Password using your Temporary Password below.</h4>
                            <asp:Label ID="lblerror" runat="server" ></asp:Label>
                        </div>
                        
                        <!-- //.section-title -->
                    </div>
                    <!-- //.col-md-12 -->
                </div>
                <!-- //.row -->
                <div class="row">
                  <div class="col-md-4" style="float: none; margin: 0 auto; border:thin; border-width:1px; border-color:#ccc;">
                    <div class="hpanel">
                <div class="panel-body">                        
                            <div class="form-group">
                                <label for="username" class="control-label">Temporary Password</label>
                                <asp:TextBox ID="txt_TempPass" placeholder="Temporary Password" runat="server" class="form-control required"  name="username"  title="Please enter Temporary Password" required></asp:TextBox>
                                <span class="help-block small"></span>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">New Password</label>
                                <asp:TextBox ID="txt_Pass_1" placeholder="New Password" TextMode="Password" runat="server" class="form-control required"  name="password"    title="Please create a New Password" required></asp:TextBox>
                                <span class="help-block small"></span>
                            </div>
                     <div class="form-group">
                                <label for="password" class="control-label">Re-Enter New Password</label>
                                <asp:TextBox ID="txt_Pass_2" placeholder="Re-Enter New Password" TextMode="Password" runat="server" class="form-control required"  name="password"    title="Re-Enter New Password" required></asp:TextBox>
                                <span class="help-block small"></span>
                            </div>
                            
                            <asp:Button ID="btn_signin" class="btn btn-success btn-block" ValidationGroup="valGroup2" CausesValidation="true" runat="server" Text="Reset Password" OnClick="btn_signin_Click" />
                            
                        
                </div>
            </div>
                </div>
                    <!-- //.col-md-12 -->
                </div>    
                <!-- //.row -->
             <br /><br /><br /><br />
           
                <!-- //.row -->
            
            <!-- //.section-content -->
             </div>
        </div>
        <!-- //.section-inner -->
    </section>
    <!-- //End Contact Us Section -->     
          
    
  

    <!-- Begin Footer -->
    <footer class="footer">

        <!-- Begin Footer Section -->
        <section id="footer">
            <div class="container">    
                <div class="row">
                    <div class="col-sm-4 col-md-4 footer-column not-right-column">
                        <div class="footer-text">
                            <h4>Get In Touch</h4>
                            
                            <div>
                                1800 Washington Boulevard, Baltimore, MD 21230
                            <p><i class="fa fa-phone"></i> 410-537-3000</p>    
                            </div>
                            
                            <ul class="social-icon-list list-unstyled list-inline">
                                <li>
                                    <a href="#"><i class="fa fa-facebook"></i></a>
                                </li>
                                
                                <li>
                                    <a href="#"><i class="fa fa-twitter"></i></a>
                                </li>
                                
                                <li>
                                    <a href="#"><i class="fa fa-google-plus"></i></a>
                                </li>
                                
                                <li>
                                    <a href="#"><i class="fa fa-youtube"></i></a>
                                </li>
                                
                                <li>
                                    <a href="#"><i class="fa fa-pinterest"></i></a>
                                </li>
                                
                                <li class="hidden-xs">
                                    <a href="#"><i class="fa fa-instagram"></i></a>
                                </li>
                            </ul>
                        </div>
                        <!-- //.footer-text -->
                    </div>
                    <!-- //.footer-column -->

                    <div class="col-sm-4 col-md-4 footer-column not-right-column">
                        <div class="footer-text">
                            <h4>Our Promise</h4>
                            
                            <p>The State of Maryland pledges to provide constituents, businesses, customers, and stakeholders with services in the following manner:</p>
                            <ul>
                                <li>Friendly and Courteous:​​ We will be helpful and supportive and have a positive attitude and passion for what we do.</li>
                                <li>Timely and Responsive:​​ We will be proactive, take initiative, and will try to anticipate your needs.</li>
                                <li>Accurate and Consistent:​​ We will always aim for 100% accuracy, and be consistent in how we interpret and implement State policies and procedures.</li>
                                <li>Accessible and Convenient:​​ We will continue to simplify and improve access to information and resources.</li>
                                <li>Truthful and Transparent:​​ We will advance a culture of honesty, clarity, and trust.</li>
                            </ul>
                        </div>
                        <!-- //.footer-text -->
                    </div>
                    <!-- //.footer-column -->

                    <div class="col-sm-4 col-md-4 footer-column">
                        <div class="footer-text">
                            <h4>MDE Stakeholders</h4>
                            
                            <p>MDE’s customers include Maryland citizens who expect protection and restoration of the environment; businesses, governments, and individuals who are applying for permits and receiving technical assistance; and technical personnel such as: well drillers, sanitarians, waste water operators, and asbestos contractors who require certification. Other key stakeholders include environmental and public health advocacy groups, citizen groups, educators, scientists and natural resource users.</p>
                            <h4>Other Resources</h4>
                            <ul>
                                <li><a href="https://mde.maryland.gov/programs/LAND/LeadPoisoningPrevention/Pages/rentalowners_inspections.aspx" title="Maryland Environmental Regulations">MD Environmental Regulations </a></li>
                                <li><a href="https://mde.maryland.gov/programs/LAND/LeadPoisoningPrevention/Pages/rentalowners_inspections.aspx" title="Maryland Environmental Regulations">MDWater Regulations </a></li>
                                <li><a href="https://mde.maryland.gov/programs/LAND/LeadPoisoningPrevention/Pages/rentalowners_inspections.aspx" title="Maryland Environmental Regulations">MD Small Businesses Regulations </a></li>
                                <li><a href="https://mde.maryland.gov/programs/LAND/LeadPoisoningPrevention/Pages/rentalowners_inspections.aspx" title="Maryland Environmental Regulations">MD Land Regulations </a></li>
                            </ul>
                            
                           
                        </div>
                        <!-- //.footer-text -->
                    </div>
                    <!-- //.footer-column -->
                </div>
                <!-- //.row -->
            </div>
            <!-- //.container -->
        </section>
        <!-- //End Footer Section -->

        <!-- Begin Copyright -->
        <div id="copyright">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <p> <a href="https://www.serigor.com"><img src="CSSFrontEnd/assets_/img/serigor_small_gray.png" /></a></p>
                        <span style="align-content:center">Copyright &copy; 2020</span>
                    </div>
                    <!-- //.col-md-12 -->
                </div>
                <!-- //.row -->
            </div>
            <!-- //.container -->
        </div>
        <!-- //End Copyright -->
    </footer>
    <!-- //End Footer -->
    
    
    <!-- Plugins JS -->
    <script src="CSSFrontEnd/assets_/plugins/jquery.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/detectmobilebrowser/detectmobilebrowser.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/smartresize/smartresize.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-easing/jquery.easing.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-backstretch/jquery.backstretch.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-sticky/jquery.sticky.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-inview/jquery.inview.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-countTo/jquery.countTo.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-easypiechart/jquery.easypiechart.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-countdown/jquery.plugin.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-countdown/jquery.countdown.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/owl-carousel/owl.carousel.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/isotope/isotope.pkgd.min.js"></script>
    <script src="CSSFrontEnd/assets_/plugins/jquery-magnificPopup/jquery.magnific-popup.min.js"></script> 
    <script src="CSSFrontEnd/assets_/plugins/jquery-validation/jquery.validate.min.js"></script>

    <script type="text/javascript" src="CSSFrontEnd/assets_/plugins/parallax-slider/js/modernizr.js"></script>
<script type="text/javascript" src="CSSFrontEnd/assets_/plugins/parallax-slider/js/jquery.cslider.js"></script> 
        <script src="CSSFrontEnd/assets/plugins/layer_slider/js/layerslider.transitions.js" type="text/javascript"></script>
<script src="CSSFrontEnd/assets/plugins/layer_slider/js/layerslider.kreaturamedia.jquery.js" type="text/javascript"></script>
<script src="CSSFrontEnd/assets_/js/index.js"></script>
         <script type="text/javascript">
            
             jQuery(document).ready(function () {

                 //Index.initParallaxSlider();
                 $(window).scrollTop(0);


                 Index.initLayerSlider();
             });

           
 // quick search regex
var qsRegex;

// init Isotope
var $grid = $('.grid').isotope({
  itemSelector: '.element-item',
  layoutMode: 'fitRows',
  filter: function() {
    return qsRegex ? $(this).text().match( qsRegex ) : true;
  }
});

// use value of search field to filter
var $quicksearch = $('.quicksearch').keyup( debounce( function() {
  qsRegex = new RegExp( $quicksearch.val(), 'gi' );
  $grid.isotope();
}, 200 ) );

// debounce so filtering doesn't happen every millisecond
function debounce( fn, threshold ) {
  var timeout;
  threshold = threshold || 100;
  return function debounced() {
    clearTimeout( timeout );
    var args = arguments;
    var _this = this;
    function delayed() {
      fn.apply( _this, args );
    }
    timeout = setTimeout( delayed, threshold );
  };
}
             
         
</script>
    <!-- Main JS -->
    <script src="CSSFrontEnd/assets_/js/main.js"></script>
    
    <!-- Animation JS (Optional) -->
    <script src="CSSFrontEnd/assets_/js/animation.js"></script>
    
    <!-- Component JS -->
    <script src="CSSFrontEnd/assets_/js/component/bar-chart.js"></script>
    <script src="CSSFrontEnd/assets_/js/component/countdown.js"></script>
    <script src="CSSFrontEnd/assets_/js/component/counters.js"></script>
    <script src="CSSFrontEnd/assets_/js/component/pie-chart.js"></script>
    <script src="CSSFrontEnd/assets_/js/component/portfolio.js"></script>
    <script src="CSSFrontEnd/assets_/js/component/animation.js"></script>
    <script src="CSSFrontEnd/assets_/js/masonry.pkgd.js"></script>
    

     
   </form>
</body>
</html>