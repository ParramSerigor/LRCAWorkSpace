<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="MDESuperAppView.aspx.cs" Inherits="LRCA.MDESuperAppView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
    <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          <asp:Label ID="lblContractorApp" runat="server" ></asp:Label></span>         
            </h2>
            <p>Application for Supervisor Accreditation<asp:Label ID="lblCourseName" runat="server" ></asp:Label>.</p>
            <p><asp:Label ID="lblContactInfo" runat="server" ></asp:Label></p>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="hpanel "  >
           
            <div >
     <div class="hpanel">
            <div class="alert" style="background-color:#fff; color:#000; text-align:center;">
            <h4 style="margin:-5px 0">LEAD PAINT ACCREDITATION APPLICATION: SUPERVISOR</h4>    
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">I. Instructions</h5>
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
                <p>
                   Fees are non-refundable. All applications, including renewals, must be filled out completely. Incomplete, inaccurate, illegible applications may be delayed during processing. Name must match your State issued ID. <b>Allow up 60 days for processing from the date your application with applicable fee was received. The Program may email you regarging incomplete. Do NOT email SSN or Tax IDs.</b> See website for reciprocity and Third Party Exam information. <i>Supervisor accreditations are valid for up to two years.</i>
                </p>
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">II. General Applicant Information</h5>
            </div>
             <div class="alert" style="background-color:#fff; color:#000;">
                <div class="row">
                      <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-12 control-label">Last Name</label>

                    <div >
                        <asp:TextBox ID="txtLName" class="form-control" placeholder="Last Name"  title="Last Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(as per your State ID)</span>
                    </div></div></div>
                     <div class="col-lg-3">
                      <div class="form-group"><label class="col-sm-10 control-label">Suffix</label>

                    <div >
                        <asp:TextBox ID="txtSuffix" class="form-control" placeholder="Suffix" title="Suffix" runat="server" required></asp:TextBox> <span class="help-block m-b-none">(e.g. Sir, Jr)</span>
                    </div></div></div>
                
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Legal First Name</label>

                     <div >
                        <asp:TextBox ID="txtFName" class="form-control" placeholder="First Name" title="First Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(as per your State ID)</span>
                    </div></div></div>

                              <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Middle Name</label>

                     <div >

                        <asp:TextBox ID="txtMName" class="form-control" placeholder="Middle Name" title="Middle Name" runat="server" required></asp:TextBox>
                    </div></div></div>
                    </div>

                <div class="row">
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Street Address</label>

                     <div >
                        <asp:TextBox ID="txtAddress_1" class="form-control" placeholder="Address line 1" title="Address line 1" runat="server" required></asp:TextBox>
                    </div></div></div>
                              <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>

                     <div >
                        <asp:TextBox ID="txtCity_1" class="form-control" placeholder="City" title="City" runat="server" required></asp:TextBox>
                    </div></div></div>
                              <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>

                     <div >
                        <asp:TextBox ID="txtState_1" class="form-control" placeholder="State" title="State" runat="server" required></asp:TextBox> 
                    </div></div></div>
                          
                    <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>

                     <div >
                        <asp:TextBox ID="txtZipCode_1" class="form-control" placeholder="Zip Code" title="Zip Code" runat="server" required></asp:TextBox>
                    </div></div></div>
                     </div>

                 <div class="row">
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Mailing Address</label>

                     <div >
                        <asp:TextBox ID="txtAddress_2" class="form-control" placeholder="Mailing Address" title="Mailing Address" runat="server"></asp:TextBox><span class="help-block m-b-none">(if different from above)</span>
                    </div></div></div>
                              <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>

                     <div >
                        <asp:TextBox ID="txtCity_2" class="form-control" placeholder="City" title="City" runat="server" ></asp:TextBox>
                    </div></div></div>
                              <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>

                     <div >
                        <asp:TextBox ID="txtState_2" class="form-control" placeholder="State" title="State" runat="server" ></asp:TextBox> 
                    </div></div></div>
                          
                    <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>

                     <div >
                        <asp:TextBox ID="txtZipcode_2" class="form-control" placeholder="Zip Code" title="Zip Code" runat="server" ></asp:TextBox>
                    </div></div></div>
                 </div>

                  <div class="row">
                       <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Telephone #</label>

                     <div >
                        <asp:TextBox ID="txtPhone" class="form-control" placeholder="Telephone" title="Telephone" runat="server" required></asp:TextBox>
                    </div></div></div>
                      <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Email Address</label>

                     <div >
                        <asp:TextBox ID="txtEmailAddress" class="form-control" placeholder="Email Address" data-inputmask="'alias': 'email'" title="Email Address" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Correspondence may be sent to this address)</span>
                    </div></div></div>
                      <div class="col-lg-3">
                      <div class="form-group"><label class="col-sm-10 control-label">Date of Birth</label>

                    <div >
                        <asp:TextBox ID="txtDOB" class="form-control" placeholder="Date of Birth" title="Date of Birth" runat="server" required></asp:TextBox>
                    </div></div></div>
                       <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Social Security Number</label>

                     <div >
                        <asp:TextBox ID="txtSSNO" class="form-control" placeholder="Social Security Number" title="Social Security Number" runat="server" required></asp:TextBox> 
                    </div></div></div>

                  </div>
            </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">III. Application Type and Fee</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-6"><h5>Have you held an accreditation with the same name and category in the past with the state of Maryland? </h5></div>
                 <div class="col-lg-2">
                     <asp:DropDownList ID="dropIsRenewal" CssClass="form-control m-b" onchange="IsRenewal()" multiple="multiple"  ToolTip="Is Renewal Application" runat="server">
                         <asp:ListItem Value="-1">Select One</asp:ListItem>
                 <asp:ListItem Value="0">NO</asp:ListItem>
                 <asp:ListItem Value="1">YES</asp:ListItem>
             </asp:DropDownList>
                 </div>
                 <div class="col-lg-2">
                     </div>
             </div>

             <div id="divIsRenewal" runat="server" class="row">
                 <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label>

                     <div >
                        <asp:TextBox ID="txtACCID" class="form-control" placeholder="Accreditation #" title="Accreditation #" runat="server" ></asp:TextBox>
                    </div></div></div>

                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Expiration Date</label>

                     <div >
                        <asp:TextBox ID="txtAccreditationExpirationDate" class="form-control" placeholder="Accreditation Expiration Date" title="Accreditation Expiration Date" runat="server" ></asp:TextBox>
                    </div></div></div>
             </div>

         </div>
        <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-6"><h5>Select Category </h5></div>
                 <div class="col-lg-4">
                     <asp:DropDownList ID="dropCategory" CssClass="form-control m-b" onchange="CategoryIs()" multiple="multiple" Width="320px"  ToolTip="Category" runat="server">
                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                        <asp:ListItem Value="4">Structural Steel Supervisor</asp:ListItem>
                        <asp:ListItem Value="6">Removal and Demolition Supervisor</asp:ListItem>
                        <asp:ListItem Value="5">Maintenance and Repainting Supervisor</asp:ListItem>
                    </asp:DropDownList>
                 </div>
             </div>
            </div>
            <div id="divCatInspection" class="alert" runat="server" style="background-color:#fff; color:#000;">
                <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Structural Steel Supervisor
                </h2> <span class="help-block">
                    <b class="text-right">fee:$150.00</b><br /> <br />
                    <b>NEW APPLICANTS ARE TO PROVIDE THE FOLLOWING</b>
                </span>
                   </div>
                </div>
                <div class="row">
                        <div class="col-lg-4">
                            <p >Two years minimum of related experience in related construction trades; </p>
                        </div>
                        <div class="col-lg-4 input-daterange input-group" id="datepicker">
                           
                                <asp:TextBox ID="txtConstTradeSteelStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server"></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtConstTradeSteelEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server"></asp:TextBox>
                            </div>
                        <div class="col-lg-4"></div>
                   </div>
                <div class="row">
                     <div class="col-lg-2">
                            <p >Employer(s) worked for?</p>
                        </div>
                     <div class="col-lg-10">
                         <asp:TextBox ID="txtSteelSuperWorkedFor" class="form-control" placeholder="Example: ANG Group, Steel Beams LLC, SMP Steel" title="Employer(s) worked for?" runat="server"></asp:TextBox>
                         </div>
                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-2">
                        Check related experience:
                    </div>
                    <div class="col-lg-10">
                        <asp:Panel ID="pnlSteelExperiences" runat="server"></asp:Panel>
                        </div>
                </div>
                    </div>
          
            <div id="divCatResidential" class="alert" runat="server" style="background-color:#fff; color:#000;">
                <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Removal & Demolition Supervisor
                </h2> <span class="help-block">
                    <b class="text-right">fee:$150.00</b><br /> <br />
                    <b>NEW APPLICANTS ARE TO PROVIDE THE FOLLOWING</b>
                </span>
                   </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                            <p >Third party exam date, was taken or registered to take on</p>
                        </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtThirdPartyRemovalDate" class="form-control" placeholder="3rd Party Date" title="3rd Party Date" runat="server"></asp:TextBox><span class="help-block m-b-none">(Third party exam fee is required for in-state exams ... $35.00)</span>        
                    </div>
                    <div class="col-lg-4"></div>
                </div>
                <br />
                <div class="row">
                        <div class="col-lg-4">
                            <p >Two years minimum of related experience in related construction trades; </p>
                        </div>
                        <div class="col-lg-4 input-daterange input-group" id="datepicker1">
                           
                                <asp:TextBox ID="txtConstTradeRemovalStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server"></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtConstTradeRemovalEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server"></asp:TextBox>
                            </div>
                        <div class="col-lg-4"></div>
                   </div>
                <div class="row">
                     <div class="col-lg-2">
                            <p >Employer(s) worked for?</p>
                        </div>
                     <div class="col-lg-10">
                         <asp:TextBox ID="txtRemovalSuperWorkedFor" class="form-control" placeholder="Example: ANG Group, Steel Beams LLC, SMP Steel" title="Employer(s) worked for?" runat="server"></asp:TextBox>
                         </div>
                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-2">
                        Check related experience:
                    </div>
                    <div class="col-lg-10">
                        <asp:Panel ID="pnlRemovalExperiences" runat="server"></asp:Panel>
                        </div>
                </div>
            </div>

            <div id="divCatSteel" class="alert" runat="server" style="background-color:#fff; color:#000;">
              <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Maintenance & Repainting Supervisor
                </h2> <span class="help-block">
                    <b class="text-right">fee:$125.00</b><br /> <br />
                    <b>NEW APPLICANTS ARE TO PROVIDE THE FOLLOWING</b>
                </span>
                   </div>
                </div>
                <div class="row">
                        <div class="col-lg-4">
                            <p >Six months minimum of related experience in related construction trades; </p>
                        </div>
                        <div class="col-lg-4 input-daterange input-group" id="datepicker2">
                           
                                <asp:TextBox ID="txtConstTradeRepaintStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server"></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtConstTradeRepaintEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server"></asp:TextBox>
                            </div>
                        <div class="col-lg-4"></div>
                   </div>
                <div class="row">
                     <div class="col-lg-2">
                            <p >Employer(s) worked for?</p>
                        </div>
                     <div class="col-lg-10">
                         <asp:TextBox ID="txtRepaintSuperWorkedFor" class="form-control" placeholder="Example: ANG Group, Steel Beams LLC, SMP Steel" title="Employer(s) worked for?" runat="server"></asp:TextBox>
                         </div>
                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-2">
                        Check related experience:
                    </div>
                    <div class="col-lg-10">
                        <asp:Panel ID="pnlRepaintExperiences" runat="server"></asp:Panel>
                        </div>
                </div>
                
            </div>
        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:2px !important; padding:1px !important">
            &nbsp;
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
         <div class="row">
                 <div class="col-lg-6">
                     <h5>Check below if it applies to the applicant.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h5> 
                 </div>
             <div class="col-lg-6">
                 <span style="float:right"><b>APPLICATION FEE WAIVED</b></span>
                 </div>
             </div>
                <div class="row">
              <div class="col-lg-6">
                 <label style="font-size:12px; padding-left:5px;padding-bottom:5px"><asp:CheckBox ID="chkWaiver" onclick="Javascript:CheckWaiver();" runat="server" />&nbsp;State or Local government, for use on behalf of, as government employee.  </label>
             </div>
             </div>
    </div>    

         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">IV. Applicant's Training Information</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12"><h5>List the latest course completed for category applying. Refresher courses are only valid when taken before prior relevant training or accreditation has expired.</h5></div>
                 </div>
             <br />
             <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Training card #</label>

                    <div >
                        <asp:TextBox ID="txtTrainingCardNum" class="form-control" placeholder="Training Card #"  title="Training Card #" runat="server" required></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">Expiration date</label>

                    <div >
                        <asp:TextBox ID="txtTrainCExpire" class="form-control" placeholder="Expiration date" title="Expiration date" runat="server" required></asp:TextBox>
                    </div></div></div>
                
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Name of training provider</label>

                     <div >
                        <asp:TextBox ID="txtTrainingProviderName" class="form-control" placeholder="Name of training provider" title="Name of training provider" runat="server" required></asp:TextBox>
                    </div></div></div>
                    </div>
             <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Course name</label>

                    <div >
                        <asp:TextBox ID="txtCourseName" class="form-control" placeholder="Course name"  title="Course name" runat="server" required></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">Course date(s)</label>

                    <div class="input-daterange input-group" id="datepicker_Course">
                           
                                <asp:TextBox ID="txtCourseStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server" required></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtCourseEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server" required></asp:TextBox>
                            </div></div></div>
             </div>
             </div>

        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">V. Employer Information</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12">
                     <h5><span style="text-decoration: underline;"><b>ALL</b></span> Inspector and Risk Assessor applicants' employers are required to be accredited as a Maryland Lead Paint Inspection Contractor. This requirement includes those who are self-employed.</h5>
                     <h5>If the contractor is not accredited or the accreditation is expiring within the next 60 days, include a <span style="text-decoration: underline;">separate</span> <i>Lead Paint Contractor Accreditation Application</i> with the application. Write your Contractor information below.</h5>
                 </div>
                 </div>
             <div class="row">
                 <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-12 control-label">Contractor Name</label>

                    <div >
                        <asp:TextBox ID="txtContractorName" class="form-control" placeholder="Contractor Name"  title="Contractor Name" runat="server" required></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-12 control-label">Contractor Accreditation #</label>

                    <div >
                        <asp:TextBox ID="txtContractorAccdNum" class="form-control" placeholder="Contractor Accreditation #"  title="Contractor Accreditation #" runat="server" required></asp:TextBox><span class="help-block m-b-none">(if already have one)</span>
                    </div></div></div>
             </div>
             <div class="row">
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-12 control-label">Street Address</label>

                    <div >
                        <asp:TextBox ID="txtIC_Address_Line_1" class="form-control" placeholder="Street Address"  title="Street Address" runat="server" ></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-12 control-label">City</label>

                    <div >
                        <asp:TextBox ID="txtIC_City" class="form-control" placeholder="City"  title="City" runat="server" ></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-12 control-label">State</label>

                    <div >
                        <asp:TextBox ID="txtIC_State" class="form-control" placeholder="State"  title="State" runat="server" ></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-12 control-label">Zip Code</label>

                    <div >
                        <asp:TextBox ID="txtIC_Zipcode" class="form-control" placeholder="Zip Code"  title="Zip Code" runat="server" ></asp:TextBox>
                    </div></div></div>
             </div>
                     <div class="row">
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Contact First Name</label>

                    <div >
                        <asp:TextBox ID="txtICContactFName" class="form-control" placeholder="Contact First Name"  title="Contact First Name" runat="server" required></asp:TextBox>
                    </div></div></div>
                          <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Contact Last Name</label>

                    <div >
                        <asp:TextBox ID="txtICContactLName" class="form-control" placeholder="Contact Last Name"  title="Contact Last Name" runat="server" required></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Telephone #</label>

                    <div >
                        <asp:TextBox ID="txtICContactPhone" class="form-control" placeholder="Telephone #"  title="Telephone #" runat="server" required></asp:TextBox>
                    </div></div></div>
             </div>
             </div>
                <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VI. Applicant Statement and Signature</h5>
            </div>
          			 <div class="alert" style="background-color:#fff; color:#000;">
                <p>This Notice is provided pursuant to 4-501 of the General Provisions Article of the Maryland Code. The personal information requested on this form is intended to be used in processing your application. Failure to provide the information requested may result in your application not being processed. You have the right to inspect, amend, or correct this form. The Maryland Department of the Environment is a public agency and subject to the Maryland Public Information Act(Md. Code Ann., General Provisions 4-101. et seq). This form may be made available on the internet via the Department's website and is subject to inspection or copying , in whole or in part, by the public and other governmental agencies, if not protected by federal or State law.</p><br />
                     <p>I certify that I shall perform work practices according to Code of Maryland Regulations (COMAR) 26.16.01 through 26.16.05 and 26.02.07. As per Environment Article 1-203 and Family Law Article 10-119.3 of Maryland before any license or permit may be issued or renewed, the issuing authority shall verify through the Office of the Comptroller and the Maryland Child Support Enforcement Administration that the applicant has no outstanding taxes, unemployment insurance contributions or child support.</p><br />
                 </div>

        <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                      <div class="col-lg-8">
                        <div class="form-group"><label class="col-sm-12 control-label">&nbsp;</label>

                    <div >
                        <label><asp:CheckBox ID="chkIAgree" runat="server" /> I Agree to the Applicant Statement above. </label>
                        
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">&nbsp;</label>

                    <div >
                       <b>Signed On: <asp:Label ID="lblDateSigned"  runat="server" ></asp:Label></b>
                        <br />
                        <b>Signed By: <asp:Label ID="lblSignedBy"  runat="server" ></asp:Label></b>
                    </div></div></div>

                

                 </div>
        </div>
    <div class="panel-footer">
                <asp:Button ID="btnAddCourse" runat="server" OnClientClick="javascript: return formIsValid();" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Update your Application" />
                </div>
     </div>
     
    </div>
               </div>
        </div>
        <asp:ScriptManager ID="ScriptManagerComment" runat="server"></asp:ScriptManager>
        <div class="col-md-4">
       <asp:PlaceHolder ID="phWriteComment" runat="server">
                <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#tab-1" aria-expanded="true"><b>Case Files</b> </a></li>
                <li class=""><a data-toggle="tab" href="#tab-2" aria-expanded="false"><b>Comments Section</b></a></li>
            </ul>
                <div class="tab-content">
               <div id="tab-1" class="tab-pane active">
                    <div class="panel-body">
                         <div class="hpanel ">
                <div class="panel-heading hbuilt">
                    <div class="panel-tools">
                        
                    </div>
                    Case files uploaded after initial submission of the application.
                </div>
                             <asp:UpdatePanel ID="UpdatePanelUpload" UpdateMode="Conditional" runat="server" >
                                 <ContentTemplate>
                <div class="panel-body no-padding">
                    <div class="chat-discussion">
                                    <asp:Panel ID="pnlUploads" runat="server"></asp:Panel>  
                                    
                                
                       
                        
                            </div>
                </div>
                    
                <div class="panel-footer borders">

                    <div class="input-group">
                        <asp:FileUpload class="btn btn-default btn-file" Width="100%"  runat="server" ID="upload_1"  />
                        <span class="input-group-btn">
                           <asp:Button ID="btnUploadF" runat="server" OnClick="UploadFiles"  CssClass="btn btn-success" Text="Upload" />
                            
                        </span>
                    </div>
                </div>
                                     </ContentTemplate>
                                 <Triggers>
                                     <asp:PostBackTrigger ControlID="btnUploadF" />
                                 </Triggers>
                                 </asp:UpdatePanel>       
            </div> 
                    </div>
                </div>
               <div id="tab-2" class="tab-pane">
                    <div class="panel-body">
                    <div class="hpanel ">
                <div class="panel-heading hbuilt">
                    <div class="panel-tools">
                        
                    </div>
                    Comments
                </div>
                <div class="panel-body no-padding">
                    <div class="chat-discussion">
                        
                        <asp:UpdatePanel ID="UpdatePanelComment" runat="server" >
                                <ContentTemplate>
                                    <asp:Panel ID="pnlComments" runat="server"></asp:Panel>  
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="CommentEnter" style = "display:none" />
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="panel-footer borders">
                    <div class="input-group">
                        <asp:TextBox ID="txtComment" class="form-control" Enabled="true" placeholder="Type your message here..." title="Type your message here..." runat="server" ></asp:TextBox>
                        <span class="input-group-btn">
                           <input type="button" class="btn btn-success" value = "Send" onclick="SubmitComment()" />
                        </span>
                    </div>
                </div>

            </div>    
                    </div>
                     </div>
            </div>
            </asp:PlaceHolder>
    </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
  <script type="text/javascript">
       $(":input").inputmask();

            $("#CPMain_txtPhone").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtSSNO").inputmask({
                mask: '999-99-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: true
            });
            $("#CPMain_txtZipCode_1").inputmask({
                mask: '99999',
                placeholder: ' ',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtZipcode_2").inputmask({
                mask: '99999',
                placeholder: ' ',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtIC_Zipcode").inputmask({
                mask: '99999',
                placeholder: ' ',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtFax").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtTrainingCardNum").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtACCID").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtContractorAccdNum").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtICContactPhone").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });

            $('#datepicker').datepicker();
            $('#datepicker1').datepicker();
             $('#datepicker2').datepicker();
            $('#datepicker_Course').datepicker();
            $('[id*=txtThirdPartyRiskAssExamDate]').datepicker({});
            $('[id*=txtDOB]').datepicker({});
            $('[id*=txtThirdPartyInspTechExamDate]').datepicker({});
            $('[id*=txtTrainCExpire]').datepicker({});

            $('[id*=txtAccreditationExpirationDate]').datepicker({});
            $('[id*=txtConstTradeSteelStartDate]').datepicker({});
            $('[id*=txtConstTradeSteelEndDate]').datepicker({});
            $('[id*=txtThirdPartyRemovalDate]').datepicker({});
            $('[id*=txtConstTradeRemovalStartDate]').datepicker({});
            $('[id*=txtConstTradeRemovalEndDate]').datepicker({});
            $('[id*=txtConstTradeRepaintStartDate]').datepicker({});
            $('[id*=txtConstTradeRepaintEndDate]').datepicker({});
            $('[id*=txtTrainCExpire]').datepicker({});
            $('[id*=txtCourseStartDate]').datepicker({});
            $('[id*=txtCourseEndDate]').datepicker({});

      $(document).ready(function () {
          $(document).on("click", ".open-AssignedToMe", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('are you sure you want to take the ownership of this application?')) {
		                CallAjax(DeleteId);
		            }
          });
           $(document).on("click", ".open-Approve", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want Approve this application?')) {
		                CallAjaxApprove(DeleteId);
		            }
          });
          $(document).on("click", ".open-Disapprove", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want Disapprove this application?')) {
		                CallAjaxDisapprove(DeleteId);
		            }
          });
          $(document).on("click", ".open-Deficient", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want Deficient this application Status?')) {
		                CallAjaxDeficient(DeleteId);
		            }
          });
          $(document).on("click", ".open-Hold", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want put this Application on Hold?')) {
		                CallAjaxHold(DeleteId);
		            }
                });
      })


      function CallAjax(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "MDESuperAppView.aspx/AssignedToMe",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
      }
      function CallAjaxApprove(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "MDESuperAppView.aspx/Approve",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
      }
      function CallAjaxDisapprove(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "MDESuperAppView.aspx/Disapprove",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
      }
      function CallAjaxDeficient(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "MDESuperAppView.aspx/Deficient",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
      }
      function CallAjaxHold(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "MDESuperAppView.aspx/Hold",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
      }
      function SubmitComment() {
          var CommVal = $('[id*=CPMain_txtComment]').val();
          
          if (!CommVal || 0 === CommVal.length) {
              alert('Comment must have some text!');
              return false;
          }
          else {
              document.getElementById("<%=btnSubmit.ClientID %>").click();
              $('[id*=CPMain_txtComment]').val('');
          }
          
      }
       function IsRenewal() {
            var SelectedVal = $('[id*=CPMain_dropIsRenewal]').val();

            if (SelectedVal == '0' || SelectedVal == '-1')
            {
                $('[id*=divIsRenewal]').hide();
                $('[id*=txtAccreditationExpirationDate]').val('');
                $('[id*=txtACCID]').val('');
            }
            else
            {
                $('[id*=divIsRenewal]').show();
            }
        }
        function CategoryIs() {
			var SelectedVal = $('[id*=CPMain_dropCategory]').val();

            $('[id*=txtConstTradeSteelStartDate]').val('');
               $('[id*=txtConstTradeSteelEndDate]').val('');
               $('[id*=txtSteelSuperWorkedFor]').val('');
               $('[id*=txtThirdPartyRemovalDate]').val('');
               $('[id*=txtConstTradeRemovalStartDate]').val('');
               $('[id*=txtConstTradeRemovalEndDate]').val('');
               $('[id*=txtRemovalSuperWorkedFor]').val('');
               $('[id*=txtConstTradeRepaintStartDate]').val('');
               $('[id*=txtConstTradeRepaintEndDate]').val('');
                $('[id*=txtRepaintSuperWorkedFor]').val('');
                $("input[name='chk_AbrasiveBlasting']:checkbox").removeAttr('checked');
                $("input[name='chk_PaintRemoval']:checkbox").removeAttr('checked');
                $("input[name='chk_Painting']:checkbox").removeAttr('checked');
                $("input[name='chk_Other']:checkbox").removeAttr('checked');
                $("input[name='chk_LeadPaintAbatement']:checkbox").removeAttr('checked');
                $("input[name='chk_Carpentry']:checkbox").removeAttr('checked');
                $("input[name='chk_Demolition']:checkbox").removeAttr('checked');
                $("input[name='chk_MaintenanceSupervision']:checkbox").removeAttr('checked');
            $("input[name='chk_PropertyManagement']:checkbox").removeAttr('checked');

            if (SelectedVal == '4') {
                $('[id*=divCatInspection]').show();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '6') {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').show();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '5') {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').hide();
				$('[id*=divCatSteel]').show();
            }
            else
            {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
            }
        }
        function CheckWaiver() {
            if ($('[id*=chkWaiver]').is(':checked'))
            {
                //Making default to 0
               $('[id*=CPMain_dropCategory]').val('0').attr('selected', 'true');
               $('[id*=CPMain_dropCategory]').attr('disabled', true);

                //Hiding all
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
               
               $('[id*=txtConstTradeSteelStartDate]').val('');
               $('[id*=txtConstTradeSteelEndDate]').val('');
               $('[id*=txtSteelSuperWorkedFor]').val('');
               $('[id*=txtThirdPartyRemovalDate]').val('');
               $('[id*=txtConstTradeRemovalStartDate]').val('');
               $('[id*=txtConstTradeRemovalEndDate]').val('');
               $('[id*=txtRemovalSuperWorkedFor]').val('');
               $('[id*=txtConstTradeRepaintStartDate]').val('');
               $('[id*=txtConstTradeRepaintEndDate]').val('');
                $('[id*=txtRepaintSuperWorkedFor]').val('');
                $("input[name='chk_AbrasiveBlasting']:checkbox").removeAttr('checked');
                $("input[name='chk_PaintRemoval']:checkbox").removeAttr('checked');
                $("input[name='chk_Painting']:checkbox").removeAttr('checked');
                $("input[name='chk_Other']:checkbox").removeAttr('checked');
                $("input[name='chk_LeadPaintAbatement']:checkbox").removeAttr('checked');
                $("input[name='chk_Carpentry']:checkbox").removeAttr('checked');
                $("input[name='chk_Demolition']:checkbox").removeAttr('checked');
                $("input[name='chk_MaintenanceSupervision']:checkbox").removeAttr('checked');
                $("input[name='chk_PropertyManagement']:checkbox").removeAttr('checked');
            }
            else
            {
                $('[id*=CPMain_dropCategory]').removeAttr('disabled');
                $('[id*=CPMain_dropCategory] [value=NA]').attr('selected', 'true');
            }
        }
      function SubmitUpload() {
          var CommVal = $('[id*=CPMain_upload_1]').val();
          if (!CommVal || 0 === CommVal.length) {
              alert('No file attached!');
              return false;
          }
          else {
              document.getElementById("<%=btnUploadF.ClientID %>").click();
              $('[id*=CPMain_upload_1]').val('');
          }
          
      }
</script>
</asp:Content>

