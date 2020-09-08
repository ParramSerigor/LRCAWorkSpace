<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCA.aspx.cs" Inherits="LRCA.AppCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Apply for Certification & Accreditation</span>         
            </h2>
            <small>Please, fill out the form below and click on submit button to send your application for approval.</small>
        </div>
          <div class="input-group"><div class="input-group-btn"><a href="#" onclick="return history.back();" class="btn btn-primary">Back</a></div><div class="alert alert-success" style="padding:8px !important;">&nbsp;</div></div>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   
     <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Certifications & Accreditations Application
                        </a>
                    </div>
                              <div class="panel-body">
                 <div class="row">
                      
                     <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Choice your Employer</label>
                    <div >
                        <asp:DropDownList ID="dropContractors" CssClass="form-control m-b" ToolTip="Registered Employer" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select registered Contractor from the dropdown list.</span>
                    </div></div></div>
                 </div>
                <br />
                <div class="row">
                      
                     <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Years of Accreditation</label>
                    <div >
                        <asp:DropDownList ID="dropYears" CssClass="form-control m-b" ToolTip="Year of Accreditation" runat="server">
                            <asp:ListItem Text="1 Year" Value="1">1 Year</asp:ListItem>
                            <asp:ListItem Text="2 Year" Value="2">2 Year</asp:ListItem>
                            <asp:ListItem Text="3 Year" Selected="True" Value="3">3 Year</asp:ListItem>
                            <asp:ListItem Text="4 Year" Value="4">4 Year</asp:ListItem>
                            <asp:ListItem Text="5 Year" Value="5">5 Year</asp:ListItem>
                        </asp:DropDownList><span class="help-block m-b-none">Select number of Years you want this Accreditation to be valid for.</span>
                    </div></div></div>
                 </div>

                <br /><br />
                <div class="well">
                     
          <h4 class="mb-3">Billing address</h4>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">First name</label>
                <input type="text" class="form-control" id="firstName" placeholder="" value="" >
                <div class="invalid-feedback">
                  Valid first name is required.
                </div>
              </div>
              <div class="col-md-6 mb-3">
                <label for="lastName">Last name</label>
                <input type="text" class="form-control" id="lastName" placeholder="" value="" >
                <div class="invalid-feedback">
                  Valid last name is required.
                </div>
              </div>
            </div>
<br />
            <div class="mb-3">
              <label for="username">Username</label>
              <div class="input-group">
                <div class="input-group-prepend">
                 
                </div>
                <input type="text" class="form-control" id="username" placeholder="Username" >
                <div class="invalid-feedback" style="width: 100%;">
                  Your username is required.
                </div>
              </div>
            </div>
                    <br />
            <div class="mb-3">
              <label for="email">Email <span class="text-muted">(Optional)</span></label>
              <input type="email" class="form-control" id="email" placeholder="you@example.com">
              <div class="invalid-feedback">
                Please enter a valid email address for shipping updates.
              </div>
            </div>
                    <br />
            <div class="mb-3">
              <label for="address">Address</label>
              <input type="text" class="form-control" id="address" placeholder="1234 Main St" >
              <div class="invalid-feedback">
                Please enter your shipping address.
              </div>
            </div>
                    <br />
            <div class="mb-3">
              <label for="address2">Address 2 <span class="text-muted">(Optional)</span></label>
              <input type="text" class="form-control" id="address2" placeholder="Apartment or suite">
            </div>
                    <br />
            <div class="row">
              <div class="col-md-5 mb-3">
                <label for="country">Country</label>
                <select class="form-control m-b" id="country" >
                  <option value="">Choose...</option>
                  <option>United States</option>
                </select>
                <div class="invalid-feedback">
                  Please select a valid country.
                </div>
              </div>
               
              <div class="col-md-4 mb-3">
                <label for="state">State</label>
                <select class="form-control m-b" id="state" >
                  <option value="">Choose...</option>
                  <option>California</option>
                </select>
               
                <div class="invalid-feedback">
                  Please provide a valid state.
                </div>
              </div>
               
              <div class="col-md-3 mb-3">
                <label for="zip">Zip</label>
                <input type="text" class="form-control" id="zip" placeholder="" >
                <div class="invalid-feedback">
                  Zip code required.
                </div>
              </div>
            </div>
                    <br />
            <hr class="mb-4">
           

            <h4 class="mb-3">Payment</h4>

            <div class="d-block my-3">
              <div class="custom-control custom-radio">
                <input id="credit" name="paymentMethod" type="radio" class="custom-control-input" checked="" >
                <label class="custom-control-label" for="credit">Credit card</label>
              </div>
              <div class="custom-control custom-radio">
                <input id="debit" name="paymentMethod" type="radio" class="custom-control-input" >
                <label class="custom-control-label" for="debit">Debit card</label>
              </div>
              <div class="custom-control custom-radio">
                <input id="paypal" name="paymentMethod" type="radio" class="custom-control-input" >
                <label class="custom-control-label" for="paypal">Paypal</label>
              </div>
            </div>
                    <br />
                     <hr class="mb-4">
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="cc-name">Name on card</label>
                <input type="text" class="form-control" id="cc-name" placeholder="" >
                <small class="text-muted">Full name as displayed on card</small>
                <div class="invalid-feedback">
                  Name on card is required
                </div>
              </div>
              <div class="col-md-6 mb-3">
                <label for="cc-number">Credit card number</label>
                <input type="text" class="form-control" id="cc-number" placeholder="" >
                <div class="invalid-feedback">
                  Credit card number is required
                </div>
              </div>
            </div>
                    <br />
            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="cc-expiration">Expiration</label>
                <input type="text" class="form-control" id="cc-expiration" placeholder="" >
                <div class="invalid-feedback">
                  Expiration date required
                </div>
              </div>
              <div class="col-md-3 mb-3">
                <label for="cc-expiration">CVV</label>
                <input type="text" class="form-control" id="cc-cvv" placeholder="" >
                <div class="invalid-feedback">
                  Security code required
                </div>
              </div>
            </div>
                </div>
               </div>
                    <div class="panel-footer">
                        <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Submit Application" />
                    </div>
                 </div>
            </div>

     </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
    <script type="text/javascript">
     $(document).ready(function () {
     $("#form1").validate({
			rules: {
				ctl00$CPMain$txtSDATNum: {
					required: true,
                    minlength: 8,
                    maxlength: 8
				},
				ctl00$CPMain$txtEIN: {
					required: true,
                    minlength: 6,
                    maxlength: 6
                },
                ctl00$CPMain$txtMHICNumber: {
                    minlength: 6,
                    maxlength: 6
                },
                ctl00$CPMain$txtACCID: {
					required: true,
                    minlength: 8,
                    maxlength: 8
				},
				email: {
					required: true,
					email: true
				},
			},
			messages: {
				ctl00$CPMain$txtSDATNum: {
					required: "Please enter valid SDAT ID",
                    minlength: "Your SDAT ID starts with W followed by 7 digits.",
                    maxlength: "Your SDAT ID must contains exact 8 characters."
                },
                ctl00$CPMain$txtACCID: {
					required: "Please enter valid ACRED ID",
                    minlength: "Your ACRED ID must have 8 digits.",
                    maxlength: "Your ACRED ID must contains exact 8 characters."
                },
                ctl00$CPMain$txtEIN: {
					required: "Please enter valid EIN Number",
                    minlength: "Your EIN Number contains 6 digits.",
                    maxlength: "Your EIN Number must contains 6 digits."
                },
                 ctl00$CPMain$txtMHICNumber: {
                    minlength: "Your MHIC Number contains 6 digits.",
                    maxlength: "Your MHIC Number must contains 6 digits."
				}
			}
		});
        });
        </script>
</asp:Content>
