<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppInspector_RiskAssessor.aspx.cs" Inherits="LRCA.AppInspector_RiskAssessor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
    <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
    <div class="hpanel">
            <div class="alert" style="background-color:#fff; color:#000; text-align:center;">
            <h4 style="margin:-5px 0">LEAD PAINT ACCREDITATION APPLICATION: INSPECTOR AND RISK ASSESSOR</h4>    
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">I. Instructions</h5>
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
                <p>
                   Fees are non-refundable. All applications, including renewals, must be filled out completely. Incomplete, inaccurate, illegible applications may be delayed during processing. Name must match your State issued ID. <b>Allow up 60 days for processing from the date your application with applicable fee was received. The Program may email you regarging incomplete. Do NOT email SSN or Tax IDs.</b> See website for reciprocity and Third Party Exam information. <i>Inspector and Risk Assessor accreditations are valid for up to two years.</i>
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
                        <asp:TextBox ID="txtPhone" class="form-control" data-inputmask="'alias':'phone'" placeholder="Telephone" title="Telephone" runat="server" required></asp:TextBox>
                    </div></div></div>
                      <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Email Address</label>

                     <div >
                        <asp:TextBox ID="txtEmailAddress" class="form-control" placeholder="Email Address"  data-inputmask="'alias': 'email'" title="Email Address" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Correspondence may be sent to this address)</span>
                    </div></div></div>
                      <div class="col-lg-3">
                      <div class="form-group"><label class="col-sm-10 control-label">Date of Birth</label>

                    <div >
                        <asp:TextBox ID="txtDOB" class="form-control" placeholder="Date of Birth" data-inputmask="'alias': 'date','placeholder': '*'"  title="Date of Birth" runat="server" required></asp:TextBox>
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
                     <asp:DropDownList ID="dropIsRenewal" CssClass="form-control m-b" onchange="IsRenewal()"  ToolTip="Is Renewal Application" runat="server">
                         <asp:ListItem Value="NA">Select One</asp:ListItem>
                 <asp:ListItem Value="0">NO</asp:ListItem>
                 <asp:ListItem Value="1">YES</asp:ListItem>
             </asp:DropDownList>
                 </div>
                 <div class="col-lg-2">
                     </div>
             </div>

             <div id="divIsRenewal" class="row">
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
                     <asp:DropDownList ID="dropCategory" CssClass="form-control m-b" onchange="CategoryIs()"  ToolTip="Category" runat="server">
                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                        <asp:ListItem Value="1">Visual Inspector</asp:ListItem>
                        <asp:ListItem Value="2">Inspector Technician</asp:ListItem>
                        <asp:ListItem Value="3">Risk Assessor</asp:ListItem>
                    </asp:DropDownList>
                 </div>
             </div>
            </div>
            <div id="divCatInspection" class="alert" style="background-color:#fff; color:#000;">
                 <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Visual Inspector
                </h2> <span class="help-block">
                    <b class="text-right">fee:$125.00</b>
                </span>
                   </div>
                     </div>
           </div>
            <div id="divCatResidential" class="alert" style="background-color:#fff; color:#000;">
                 <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Inspector Technician
                </h2> <span class="help-block">
                    <b class="text-right">fee:$125.00</b><br /> <br />
                    <b>IF HAVE NOT HELD THIS CATEGORY WITH MD IN PAST COMPLETE THE FOLLOWING</b>
                </span>
                   </div>
                </div>
                    <div class="row">
                         <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Third party exam date, was taken or registered to take on</label>

                     <div >
                        <asp:TextBox ID="txtThirdPartyInspTechExamDate" class="form-control" placeholder="Third Party Exam Date" title="Third Party Exam Date" runat="server"></asp:TextBox> <span class="help-block m-b-none">Third party exam fee is required for in-state exams $35.00</span>
                    </div></div></div>
                        <div class="col-lg-6">
                            <p ></p>
                        </div>
                    </div>
            </div>
            <div id="divCatSteel" class="alert" style="background-color:#fff; color:#000;">
                   <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Risk Assessor
                </h2> <span class="help-block">
                   <b class="text-right">fee:$200.00</b><br /><br />
                    <b>IF HAVE NOT HELD THIS CATEGORY WITH MD IN PAST COMPLETE THE FOLLOWING</b>
                </span>
                   </div>
                     </div>
                <div class="row">
                         <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Third party exam date, was taken or registered to take on</label>

                     <div >
                        <asp:TextBox ID="txtThirdPartyRiskAssExamDate" class="form-control" placeholder="Third Party Exam Date" title="Third Party Exam Date" runat="server"></asp:TextBox> <span class="help-block m-b-none">Third party exam fee is required for in-state exams $35.00</span>
                    </div></div></div>
                   </div>
                <div class="row">
                        <div class="col-lg-4">
                            <p >One year minimum experience as a Maryland accredited Inspector Technician: </p>
                        </div>
                        <div class="col-lg-4 input-daterange input-group" id="datepicker">
                           
                                <asp:TextBox ID="txtMinEx_Start" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server"></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtMinEx_End" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server"></asp:TextBox>
                            </div>
                        <div class="col-lg-4"></div>
                   </div>
                <div class="row">
                     <div class="col-lg-6">
                            <p >Inspector Technician accreditation #: <asp:TextBox ID="txtInTechAccred" class="form-control" placeholder="Inspector Technician Accreditation" title="Inspector Technician Accreditation" runat="server"></asp:TextBox>.</p>
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
                        <asp:TextBox ID="txtICContactFName" class="form-control" placeholder="Contact First Name"  title="Contact First Name" runat="server" ></asp:TextBox>
                    </div></div></div>
                          <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Contact Last Name</label>

                    <div >
                        <asp:TextBox ID="txtICContactLName" class="form-control" placeholder="Contact Last Name"  title="Contact Last Name" runat="server" ></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Telephone #</label>

                    <div >
                        <asp:TextBox ID="txtICContactPhone" class="form-control" placeholder="Telephone #"  title="Telephone #" runat="server" ></asp:TextBox>
                    </div></div></div>
             </div>
             </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VI. Risk Assessor Experience (New Risk Assessor Applicants ONLY)</h5>
            </div>
          <div class="alert" style="background-color:#fff; color:#000;">
                <p>Upload a list of twenty (20) different addresses where XFR or paint chip sampling was performed. OR a list of five addresses where XFR or paint chip sampling was performed and fifteen addresses where lead dust inspections were performed. This is pursuant to Code of Maryland Regulations (COMAR) 26.16.01.16.C(I)(b). For further details and reciprocity information, please see website. </p><br />
                <p>Please download the file and enter all required information.</p><br />
                <p>File format: Number, Date, Address, City, State, ZipCode, Type of Inspection (i.e. XRF, paint chip, or dust)</p>
                 <span >
		            <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload" style="display:none;" />			 
                 </span>   
                 </div>
                <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VII. Applicant Statement and Signature</h5>
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
                       <b>Today's Date <asp:Label ID="lblDateSigned"  runat="server" ></asp:Label></b>
                        
                    </div></div></div>

                

                 </div>
        </div>
   <div class="panel-footer">
                        <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClientClick="javascript: return formIsValid();" OnClick="AddTManual_Click" Text="Submit your Application" />
                    </div>

    
    </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
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
            $("#CPMain_txtInTechAccred").inputmask({
                mask: '999999',
                placeholder: '999999',
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
            $('#datepicker_Course').datepicker();
            $('#CPMain_txtThirdPartyRiskAssExamDate').datepicker({});
            $('#CPMain_txtDOB').datepicker({});
            $('#CPMain_txtThirdPartyInspTechExamDate').datepicker({});
            $('#CPMain_txtTrainCExpire').datepicker({});
            $('#CPMain_txtAccreditationExpirationDate').datepicker({});

            $('[id*=divIsRenewal]').hide();
            $('[id*=divCatInspection]').hide();
            $('[id*=divCatResidential]').hide();
            $('[id*=divCatSteel]').hide();


         $("#form1").validate({
			rules: {
			},
			messages: {
			}
		});
        });
        function IsRenewal() {
            var SelectedVal = $('[id*=CPMain_dropIsRenewal]').val();

            if (SelectedVal == '0' || SelectedVal == 'NA')
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
			$('[id*=upload]').hide();
            if (SelectedVal == '1') {
                $('[id*=divCatInspection]').show();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '2') {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').show();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '3') {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').hide();
				$('[id*=divCatSteel]').show();
				$('[id*=upload]').show();
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
                $('[id*=upload]').hide();

               $('[id*=txtThirdPartyInspTechExamDate]').val('');
               $('[id*=txtThirdPartyRiskAssExamDate]').val('');
               $('[id*=txtMinEx_Start]').val('');
               $('[id*=txtMinEx_End]').val('');
                $('[id*=txtInTechAccred]').val('');
                 
            }
            else
            {
                $('[id*=CPMain_dropCategory]').removeAttr('disabled');
                $('[id*=CPMain_dropCategory] [value=NA]').attr('selected', 'true');
            }
        }
        function formIsValid(){
            var IAgree = $('[id*=chkIAgree]').is(':checked');
            var FileVal = $('[id*=upload]').val().length;
            var CatIs = $('[id*=CPMain_dropCategory]').val();
            var ChkRenewal = $('[id*=CPMain_dropIsRenewal]').val();
            var IsWaiver =$('[id*=chkWaiver]').is(':checked');

            if (!(IsWaiver) && CatIs == 0) {
                alert('Please, Select a Category or select Checkbox - State or Local government, for use on behalf of, as government employee.');
                return false;
            }

            if (ChkRenewal == 'NA') {
                alert('Please, Select either NO or YES from Have you held an accreditation with the same name and category in the past with the state of Maryland?');
                return false;
            }

            if (!IAgree) {
                alert('Please, Click on I Agree Statement before submitting your application!');
                return false;
            }

                if (CatIs == 3) {
                    if (FileVal == 0) {
                    alert('Please, Upload Risk Assessor Experience file!');
                    return false;
                    }

            }
        }
        </script>
</asp:Content>
