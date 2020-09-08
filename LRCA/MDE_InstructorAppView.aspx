<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="MDE_InstructorAppView.aspx.cs" Inherits="LRCA.MDE_InstructorAppView" %>
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
            <p>Application for Instructor Accreditation<asp:Label ID="lblCourseName" runat="server" ></asp:Label>.</p>
            <p><asp:Label ID="lblContactInfo" runat="server" ></asp:Label></p>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div class="hpanel "  >
         
           
       <div class="hpanel">
            <div class="alert" style="background-color:#fff; color:#000; text-align:center;">
            <h4 style="margin:-5px 0">LEAD PAINT ACCREDITATION APPLICATION: INSTRUCTOR</h4>    
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">I. Instructions</h5>
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
                <p>
                   Fees are non-refundable. All applications, including renewals, must be filled out completely. Incomplete, inaccurate, illegible applications may be delayed during processing. Name must match your State issued ID. <b>Allow up 60 days for processing from the date your application with applicable fee was received. The Program may email you regarging incomplete. Do NOT email SSN or Tax IDs.</b> See website for reciprocity and Third Party Exam information. <i>Instructor accreditations are valid for up to one year.</i>
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
                        <asp:TextBox ID="txtPhone" class="form-control"  placeholder="Telephone" title="Telephone" runat="server" required></asp:TextBox>
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
             <h5 style="margin:-5px 0">III. Training Provider Information </h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Full Name Training Provider</label>
                     <div>
                        <asp:TextBox ID="txtInstructTP" class="form-control"  placeholder="Full Name Training Provider" title="Full Name Training Provider" runat="server" required></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label>
                     <div>
                        <asp:TextBox ID="txtInstructAcctNum" class="form-control"  placeholder="Accreditation #" title="Accreditation #" runat="server" ></asp:TextBox><span class="help-block m-b-none">(if exists)</span>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Contact First Name</label>
                     <div>
                        <asp:TextBox ID="txtInstructContFN" class="form-control"  placeholder="Contact First Name" title="Contact First Name" runat="server" required></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Contact Last Name</label>
                     <div>
                        <asp:TextBox ID="txtInstructContLN" class="form-control"  placeholder="Contact Last Name" title="Contact Last Name" runat="server" required></asp:TextBox>
                    </div></div></div>
             </div>
              <div class="row">
                 <div class="col-lg-2">
                        <div class="form-group"><label class="col-sm-10 control-label">Telephone #</label>
                     <div>
                        <asp:TextBox ID="txtInstructContPhone" class="form-control"  placeholder="Telephone #" title="Telephone #" runat="server"></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Street Address</label>
                     <div>
                        <asp:TextBox ID="txtInstructContAddress" class="form-control"  placeholder="Street Address" title="Street Address" runat="server" ></asp:TextBox><span class="help-block m-b-none">(if exists)</span>
                    </div></div></div>
                 <div class="col-lg-2">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>
                     <div>
                        <asp:TextBox ID="txtInstructContCity" class="form-control"  placeholder="City" title="City" runat="server" ></asp:TextBox>
                    </div></div></div>
                 <div class="col-lg-2">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>
                     <div>
                        <asp:TextBox ID="txtInstructContState" class="form-control"  placeholder="State" title="State" runat="server" ></asp:TextBox>
                    </div></div></div>
                  <div class="col-lg-2">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>
                     <div>
                        <asp:TextBox ID="txtInstructContZipcode" class="form-control"  placeholder="Zip Code" title="Zip Code" runat="server" ></asp:TextBox>
                    </div></div></div>
             </div>
             </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">IV. Application History </h5>
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
        
      

         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">V. Instructor Categories</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12"><p><b>Use a separate application for each category applying for. Attach documentation pertaining to each application as required.</b> A new instructor must have no more than two years between trainings and are to submit course certificate(s) with application.</p></div>
                 </div>
            <div class="row">
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">Select Categories</label>
                    <div >
                        <asp:DropDownList ID="dropInstructCategory" CssClass="form-control m-b" ToolTip="Instructor Category" runat="server">
                        </asp:DropDownList>
                    </div></div></div>
                 <div class="col-lg-4">
                                      <div class="form-group"><label class="col-sm-12 control-label">New Initial Training Card #</label>

                    <div >
                        <asp:TextBox ID="txtNewInitTrainingCard" class="form-control" placeholder="New Initial Training Card Number"  title="New Initial Training Card Number" runat="server" required></asp:TextBox>
                    </div></div>
                                 </div>
                 <div class="col-lg-4">
                    <div class="form-group"><label class="col-sm-10 control-label">New Dates of Initial Training</label>

                    <div class="input-daterange input-group" id="datepicker_Course">
                           
                                <asp:TextBox ID="txtNewInitStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server" ></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtNewInitEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server" ></asp:TextBox>
                            </div></div>
                </div>
                </div>
             <div class="row">

                <div class="col-lg-4">
                    &nbsp;
                </div>
                <div class="col-lg-4">
                    <div class="form-group"><label class="col-sm-12 control-label">Renewal Latest Training Card #</label>

                    <div >
                        <asp:TextBox ID="txtRenewalTrainingCard" class="form-control" placeholder="Renewal Latest Training Card Number"  title="Renewal Latest Training Card Number" runat="server" ></asp:TextBox>
                    </div></div>
                </div>
                  <div class="col-lg-4">
                    <div class="form-group"><label class="col-sm-10 control-label">Renewal Dates of Latest Training</label>

                    <div class="input-daterange input-group" id="datepicker_Renew">
                           
                                <asp:TextBox ID="txtRenewalStartDate" class="form-control"  name="start" placeholder="From Date" title="From Date" runat="server" ></asp:TextBox>        
                                        <span class="input-group-addon">to</span>
                                        <asp:TextBox ID="txtRenewalEndDate" class="form-control" name="end" placeholder="To Date" title="To Date" runat="server" ></asp:TextBox>
                            </div></div>
                </div>
            </div>
             </div>
        
        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VI. Instructor Exam</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12">
                     <p>An Instructor exam is required initially and at each renewal of accreditation. A 90% or higher grade is required to pass. Exams are given on the second Wednesday of every month at 9:30 a.m. at MDE in Baltimore.</p>
                     <br />
                     <p><b>Submit the application and call to register for the exam at: 410-537-3825.*</b></p>
                     <br />
                     <p>Be sure to register for this exam and any other Instructor category exams together. If applying for multiple categories, only the superseding category exam will be required.</p>
                 </div>
                 </div>
             </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VII. Experience</h5>
            </div>
          <div class="alert" style="background-color:#fff; color:#000;">
                <p>Complete and/or attach the following, as applicable: </p><br />
                <p><b>New Instructors</b></p>
                <p>Attach a list of experience of onsite lead paint abatement projects which have been conducted in accordance with COMAR 26.02.07 or other lead paint abatement standards established by the Department (example: clearance testing).</p>
                <p>Organize your list in the following way:</p>
                <p>At top of page: Name of Applicant</p>
                <p>In a table format: Number, Date, Address, City, State, Zip Code, Description of Experience</p>
                 <span >
					 <asp:HyperLink runat="server" ID="lkuploadNewInstructors" CssClass="btn btn-xs btn-success" Target="_blank"></asp:HyperLink>
                 </span>   
              <br /><br />
              <p><b>New and Renewal Inspector Technician Instructors</b></p>
              <p>You must be currently accredited as Inspector Technician or Risk Assessor</p>
              <div class="col-lg-8; input-group"><span class="input-group-addon">Accreditation #:</span><asp:TextBox ID="txtNewRenewAcctNum" class="form-control"  placeholder="Accreditation #" title="Accreditation #" runat="server" ></asp:TextBox><span class="input-group-addon">Expiration date:</span><asp:TextBox ID="txtNewRenewAcctExpireDate" class="form-control"  placeholder="Expiration Date" title="Expiration Date" runat="server" ></asp:TextBox> </div>
              <br />
              <p><b>New Inspector Technician Instructors</b></p>
              <p>Attach a list that reflects 6 months of lead paint inspection work, using a protable XRF devices and relevant techniques.</p>
              <p>Organize your list in the following way</p>
              <p>At top of page: Name of Applicant</p>
              <p>In a table format: Number, Date, Address, City, State, Zip Code, Description of Experience</p>
               <span >
				   <asp:HyperLink runat="server" ID="lkuploadNewInspectorTech" CssClass="btn btn-xs btn-success" Target="_blank"></asp:HyperLink>
                 </span> 
              <br />
                 </div>
                <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VIII. Applicant Statement and Signature</h5>
            </div>
          			 <div class="alert" style="background-color:#fff; color:#000;">
                <p>This Notice is provided pursuant to 4-501 of the General Provisions Article of the Maryland Code. The personal information requested on this form is intended to be used in processing your application. Failure to provide the information requested may result in your application not being processed. You have the right to inspect, amend, or correct this form. The Maryland Department of the Environment is a public agency and subject to the Maryland Public Information Act(Md. Code Ann., General Provisions 4-101. et seq). This form may be made available on the internet via the Department's website and is subject to inspection or copying , in whole or in part, by the public and other governmental agencies, if not protected by federal or State law.</p><br />
                     <p>I certify that I shall perform work practices according to Code of Maryland Regulations (COMAR) 26.16.01 through 26.16.05 and/or 26.02.07. As per Environment Article 1-203 and Family Law Article 10-119.3 of Maryland before any license or permit may be issued or renewed, the issuing authority shall verify through the Office of the Comptroller and the Maryland Child Support Enforcement Administration that the applicant has no outstanding taxes, unemployment insurance contributions or child support.</p><br />
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
        <asp:ScriptManager ID="ScriptManagerComment" runat="server"></asp:ScriptManager>
        <div class="col-md-4">
        <asp:PlaceHolder ID="phWriteComment" runat="server">
                <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#tab-1" aria-expanded="true"><b>Case Files</b></a></li>
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
		            url: "MDE_InstructorAppView.aspx/AssignedToMe",
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
		            url: "MDE_InstructorAppView.aspx/Approve",
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
		            url: "MDE_InstructorAppView.aspx/Disapprove",
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
		            url: "MDE_InstructorAppView.aspx/Deficient",
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
		            url: "MDE_InstructorAppView.aspx/Hold",
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
</script>
</asp:Content>