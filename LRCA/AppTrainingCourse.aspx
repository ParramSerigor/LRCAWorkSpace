<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppTrainingCourse.aspx.cs" Inherits="LRCA.AppTrainingCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
    <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div>
    <div class="hpanel">
            <div class="alert" style="background-color:#fff; color:#000; text-align:center;">
            <h4 style="margin:-5px 0">LEAD PAINT ACCREDITATION APPLICATION: TRAINING COURSE</h4>    
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">I. Instructions</h5>
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
                <p>
                   Incorporated & Limited Liability Companies shall be registered and in "Good Standing" with Maryland Department of Assessments & Taxation (SDAT) to be approved. Trade names are to be registered with SDAT. All applications, including renewals, must be filled out completely. Incomplete, inaccurate, illegible applications may be delayed during processing. <b>Allow up 60 days for processing from the date your application was received. The Program may email you regarging incomplete. Do NOT email SSN or Tax IDs.</b> <i>Additional Documentation or verification may be required. Full hard copies may be requested for Department's files. Training Provider and Training Course accreditations coincide and are valid for up to one year. </i>
                </p>
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">II. General Applicant Information</h5>
            </div>
             <div class="alert" style="background-color:#fff; color:#000;">
                <div class="row">
                     <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Full Legal Name of Training Provider</label>

                     <div >
                        <asp:TextBox ID="txtTPName" class="form-control" placeholder="Full Legal Name of Training Provider" title="Full Legal Name of Training Provider" runat="server" required></asp:TextBox>
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
                        <asp:TextBox ID="txtAddress_2" class="form-control" placeholder="Mailing Address" title="Mailing Address" runat="server"></asp:TextBox><span class="help-block m-b-none">(if left blank mailings will go to above address)</span>
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
                      <div class="form-group"><label class="col-sm-10 control-label">Fax #</label>

                    <div >
                        <asp:TextBox ID="txtFax" class="form-control" placeholder="Fax Number" title="Fax Number" runat="server" ></asp:TextBox>
                    </div></div></div>
                      <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Email Address</label>

                     <div >
                        <asp:TextBox ID="txtEmailAddress" class="form-control" placeholder="Email Address" data-inputmask="'alias': 'email'" title="Email Address" runat="server" required></asp:TextBox>
                    </div></div></div>
                     
                       <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Tax-ID</label>

                     <div >
                        <asp:TextBox ID="txtSSN" class="form-control" placeholder="FEIN or SSN" title="FEIN or SSN" runat="server" required></asp:TextBox><span class="help-block m-b-none">(EFIN or SSN)</span> 
                    </div></div></div>

                  </div>
            </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">III. Application Type</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-6"><h5>Have you held an accreditation with the same category in the past with the state of Maryland? </h5></div>
                 <div class="col-lg-2">
                     <asp:DropDownList ID="dropIsRenewal" CssClass="form-control m-b" onchange="IsRenewal()"  ToolTip="Is Renewal Application" runat="server">
                         <asp:ListItem Value="-1">Select One</asp:ListItem>
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
             <h5 style="margin:-5px 0">IV. Training Course Category</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12"><p><b>User a separate application for each category applying and attach documentation pertaining to each application as required.</b> Course Completion Certificates for each <b>new</b> accreditation must be included. On separate sheets, include all relative field experience, contractor's or training provider's names, addresses, and telephone numbers, Verification or further documents may be requested by MDE during the application review process.</p></div>
                 </div>
             </div>
        <div class="alert" style="background-color:#fff; color:#000;">
            <h5><b>Check one</b></h5>
            <fieldset id="TCCat">
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkRiskAssessor" runat="server" GroupName="TCCat" /> Risk Assessor </label>
                </div>
            </div>
                </fieldset>
            
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkInspectorTech"  runat="server" GroupName="TCCat" /> Inspector Technician </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkVisualInspector"   runat="server" GroupName="TCCat" /> Visual Inspector </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkMainRepaint" runat="server" GroupName="TCCat" /> Maintenance & Repainting Supervisor </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkRemoval" runat="server" GroupName="TCCat" /> Removal & Demolition Supervisor </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkProjectDesign" runat="server" GroupName="TCCat" /> Project Designer </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkAbatmentEnglish" runat="server" GroupName="TCCat" /> Abatement Worker English </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkAbatmentSpanish" runat="server" GroupName="TCCat" /> Abatement Worker Spanish </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkStructSteelSuper" runat="server" GroupName="TCCat" /> Structural Steel Supervisor </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label><asp:RadioButton ID="chkStructSteelWorker" runat="server" GroupName="TCCat" /> Structural Steel Worker </label>
                </div>
            </div>
            </div>

        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">V. Required Documentation</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12">
                     <p>Upload the following with this application accordingly. These are to be labeled according to the course category.</p>      
                     <p><b>Both Intial and Refresher Curriculums are required regardless if the Training Provider will only be offing one of them.</b></p>
                 </div>
                 </div>
             </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12">
                     <p><b>New Course Applications</b></p>
                     
                     <ul class="list-unstyled">
                    <li>I. Curriculum
                        <ul>
                            <li>a. Learning Objectives</li>
                            <li><b>*b. Outline/agenda of course content including time for specific topics.</b>
                                <ul>
                                    <li>i. Provide a seperate outline for the Initial and Refresher courses (except for courses where Initial and Refresher are both one day).</li>
                                    <li>ii. Agenda is to be up to date and instructors are to follow it.</li>
                                    <li>iii. Ensure that the agendas reflect no less than the minimum amount of time required for the course.</li>
                                </ul>
                            </li>
                            <li>c. Description of Learning activities (classroom participation and hands-on activities).</li>
                            <li>d. List of audio, visual, and other teaching materials being utilized.</li>
                            <li>e. Copies of all printed instruction materials (handouts) given to students.</li>
                            <li>f. Written plan of administering the examination.
                                <ul>
                                    <li>i. Copy of examinations.</li>
                                </ul>
                            </li>
                            <li>g. Written plan for providing photo indentification, training certificate, and student information.</li>
                        </ul>
                        <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload_1"  />	
                        <br />
                    </li>
                         <li><b>*III. Instructors</b>
                             <ul>
                                 <li>a. List of Designated Primary Instructor(s) for the course. Primary Instructor(s) must be accredited by MDE.</li>
                                 <li>b. List of Recognized Expert Instructor(s) for this course, if applicable.
                                     <ul><li>Documentation of qualifications for each Recognized Expert for this course (see COMAR 26.16.01.18B)</li></ul>
                                 </li>
                             </ul>
                             <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload_2"  />	
                        <br />
                         </li>
                         <li>IV. Facilities
                             <ul>
                                 <li>a. List of training facility location(s) with address(es).</li>
                                 <li>b. Description of training facilities to accommodate curriculum specified(seating, tables, area to perform hands-on activities).</li>
                             </ul>
                              <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload_3"  />	
                        <br />
                         </li>
                         <li>V. If this is a foreign language course application, then also include:
                             <ul>
                                 <li>a. A signed statement in English that the Instructor(s) listed are fluent in the language of the course.</li>
                                 <li>b. Copies of all printed handouts given to students including agendas and examinations in the language of the course.
                                     <ul>
                                         <li>i. A signed statement verifying the accuracy of the translations for these materials.</li>
                                     </ul>
                                 </li>
                             </ul>
                              <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload_4"  />	
                        <br />
                         </li>
                </ul>
                     
                 </div>
                 </div>
                 </div>
        <div class="alert" style="background-color:#fff; color:#000;">
            <div class="row">
                
                <div class="col-lg-12">
                    <p><b>Renewal Course Applications:</b></p>
                    <ul>
                        <li>I. Copy of <b>all changed</b> materials such as: handouts, booklets, outline/agenda and examinations.</li>
                        <li>II. Copy of the <b>asterisked(*)</b> items above, even if it has not been changed.</li>
                    </ul>
                     <asp:FileUpload class="btn btn-primary btn-file"  runat="server" ID="upload_5"  />	
                </div>
            </div>
            </div>
                <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VI. Applicant Statement and Signature</h5>
            </div>
          			 <div class="alert" style="background-color:#fff; color:#000;">
                <p>This Notice is provided pursuant to 4-501 of the General Provisions Article of the Maryland Code. The personal information requested on this form is intended to be used in processing your application. Failure to provide the information requested may result in your application not being processed. You have the right to inspect, amend, or correct this form. The Maryland Department of the Environment ("Department") is a public agency and subject to the Maryland Public Information Act(Md. Code Ann., General Provisions 4-101. et seq). This form may be made available on the internet via the Department's website and is subject to inspection or copying , in whole or in part, by the public and other governmental agencies, if not protected by federal or State law.</p><br />
                <p>As per Environment Article I-203 and Family Law Article 10-119.3 of Maryland before any license or permit may be issued or renewed, the issuing authority shall verify through the Office of the Comptroller and the Maryland Child Support Enforcement Administration that the applicant has no outstanding taxes, unemployment insurance contributions or child support.</p>
                           <p>I herby request that the above contractor be accredited as a Lead Paint Abatement Services Contractor in the State of Maryland. I certify that, for the purpose of performing lead paint services, the aforementioned will only employ, hire or contract with the individuals or companies that are qualified under Code of Maryland Regulations (COMAR) 26.16.01. I certify that my company and its employees shall perform work practices according to COMAR 26.16.01 and/or 26.02.07. I certify that work performed and certificates issued by my company and its employees will satisfy the requirements of Environment Article 6-8 and COMAR 26.16.01 through 26.16.05</p><br />
                 </div>

        <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">First Name</label>

                    <div >
                        <asp:TextBox ID="txtAuthRepContFName" class="form-control" placeholder="First Name"  title="First Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Authorized Representative of Training Provider First Name)</span>
                    </div></div></div>
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                    <div >
                        <asp:TextBox ID="txtAuthRepContLName" class="form-control" placeholder="Last Name" title="Last Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Authorized Representative of Training Provider Last Name)</span>
                    </div></div></div>
                    <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">Title</label>

                    <div >
                        <asp:TextBox ID="txtAuthRepContTitle" class="form-control" placeholder="Title" title="Title" runat="server" required></asp:TextBox>
                    </div></div></div>
                 </div>
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
                        <asp:Button ID="btnAddCourse" runat="server" OnClientClick="javascript: return formIsValid();" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Submit your Application" />
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
            $("#CPMain_txtSSN").inputmask({
                mask: '999999999',
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
      
        function formIsValid(){
            var IAgree = $('[id*=chkIAgree]').is(':checked');
            var FileVal1 = $('[id*=upload_1]').val().length;
            var FileVal2 = $('[id*=upload_2]').val().length;
            var FileVal3 = $('[id*=upload_3]').val().length;
            var FileVal4 = $('[id*=upload_4]').val().length;
            var FileVal5 = $('[id*=upload_5]').val().length;
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

            if (FileVal1 == 0) {
               alert('Please, Upload Curriculum file!');
               return false;
            }
             if (FileVal2 == 0) {
               alert('Please, Upload Instructors file!');
               return false;
            }
             if (FileVal3 == 0) {
               alert('Please, Upload Facilities file!');
               return false;
            }
             if (FileVal4 == 0) {
               alert('Please, Upload  foreign language course application file!');
               return false;
            }
             if (FileVal5 == 0) {
               alert('Please, Upload Renewal Course Applications file!');
               return false;
            }

            
        }
        </script>
</asp:Content>
