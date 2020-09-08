<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppContractor.aspx.cs" Inherits="LRCA.AppContractor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
    <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
    
    <div class="hpanel">
            <div class="alert" style="background-color:#fff; color:#000; text-align:center;">
            <h4 style="margin:-5px 0">LEAD PAINT ACCREDITATION APPLICATION: CONTRACTOR</h4>    
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">I. Instructions</h5>
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
                <p>
                   Fees are non-refundable. Incorporated & Limited Liability Companies shall be registered and in “Good Standing” with the Maryland Department of Assessments & Taxation (SDAT) to be approved. Trade names are to be registered with SDAT. Name Changes require a new application and fee. All applications, including renewals, must be filled out completely. Incomplete, inaccurate, illegible applications may be delayed during processing. <b>Allow up 60 days for processing from the date your application with applicable fee was received. The Program may email you regarding incomplete applications or if this is an approval of a new Inspection Contractor. DO NOT Email SSN or TAX IDs.</b><i>Contractor accreditations are valid for up to two years.</i>
                </p>
            </div>
            <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">II. General Applicant Information</h5>
            </div>
             <div class="alert" style="background-color:#fff; color:#000;">
                <div class="row">
                      <div class="col-lg-8">
                        <div class="form-group"><label class="col-sm-12 control-label">Full Legal Name of Contractor</label>

                    <div >
                        <asp:TextBox ID="txtName" class="form-control" placeholder="Company Name"  title="Contractor Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(if not a company or using a trade name, use your full individual name)</span>
                    </div></div></div>
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">SDAT#</label>

                    <div >
                        <asp:TextBox ID="txtSDATNum" class="form-control" placeholder="SDAT Number" title="SDAT Number" runat="server" required></asp:TextBox> <span class="help-block m-b-none">(if company or trade name)</span>
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
                        <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Which Addresses above should be listed on public listings</label>

                     <div>
                         <asp:DropDownList ID="dropPublicList" CssClass="form-control m-b" onchange="javascript:CheckMailingAddress();"  ToolTip="Which Addresses above should be listed on public listings" runat="server">
                         <asp:ListItem Value="-1">Select One</asp:ListItem>
                 <asp:ListItem Value="1">Street Address</asp:ListItem>
                 <asp:ListItem Value="2">Mailing Address</asp:ListItem>
             </asp:DropDownList>
                    </div></div></div>
                     <div class="col-lg-6">
                        
                    </div></div>
               

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
                        <asp:TextBox ID="txtEmailAddress" class="form-control" data-inputmask="'alias': 'email'" placeholder="Company Email" title="Company Email" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Correspondence may be sent to this address)</span>
                    </div></div></div>
                      <div class="col-lg-3">
                      <div class="form-group"><label class="col-sm-10 control-label">Tax ID</label>

                    <div >
                        <asp:TextBox ID="txtEIN" class="form-control" placeholder="Tax ID" title="Tax ID" runat="server" required></asp:TextBox> <span class="help-block m-b-none">(FEIN or SSN)</span>
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
        <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-6"><h5>Select Category </h5></div>
                 <div class="col-lg-4">
                     <asp:DropDownList ID="dropCategory" CssClass="form-control m-b" onchange="CategoryIs()"  ToolTip="Category" runat="server">
                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                        <asp:ListItem Value="10">Inspection</asp:ListItem>
                        <asp:ListItem Value="11">Residential, Commercial, & Public Building</asp:ListItem>
                        <asp:ListItem Value="12">Steel Structure</asp:ListItem>
                    </asp:DropDownList>
                 </div>
             </div>
            </div>
            <div id="divCatInspection" class="alert" style="background-color:#fff; color:#000;">
                 <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Inspection 
                </h2> <span class="help-block">
                    <b class="text-right">fee:$250.00</b><br /> Add employees who are accredited or are applying to be accredited as a Visual Inspector, Inspector Technician, and/or Risk Assessor.
                </span>
                   
                   </div>
               
                     <div class="col-lg-12">
                <div class="input-group"><div class="input-group-btn">
                     <input type='button' class="btn btn-xs btn-success" value='ADD EMPLOYEE' id='addButtonInspection'>
                        <input type='button' class="btn btn-xs btn-danger" value='REMOVE EMPLOYEE' id='removeButtonInspection'>
                </div></div>
                    </div>
                     </div>
                <br />
               
                <div id="InspectionGroup">
                <div id="InspectorEmp_1" class="row">
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">First Name</label>

                     <div >
                        <asp:TextBox ID="InspectorEmpFN_1" class="form-control" placeholder="First Name" title="First Name" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                     <div >
                        <asp:TextBox ID="InspectorEmpLN_1" class="form-control" placeholder="Last Name" title="Last Name" runat="server"></asp:TextBox>
                    </div></div></div>
                    <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label>
                     <div>
                        <asp:TextBox ID="InspectorAcctId_1" class="form-control" placeholder="Accreditation #" title="Accreditation #" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label>
                     <div >
                         <asp:DropDownList ID="dropIsApplyInspector_1" CssClass="form-control m-b"  ToolTip="Is Applying for Accreditation" runat="server">
                             <asp:ListItem Value="-1">Select One</asp:ListItem>
                             <asp:ListItem Value="0">NO</asp:ListItem>
                             <asp:ListItem Value="1">YES</asp:ListItem>
                        </asp:DropDownList>
                    </div></div></div>
                     
                </div>
                </div>
           </div>
            <div id="divCatResidential" class="alert" style="background-color:#fff; color:#000;">
                 <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Residential, Commercial, & Public Building
                </h2> <span class="help-block">
                    <b class="text-right">fee:$250.00</b><br /> Add employees who are accredited or are applying to be accredited as a Maintenance & Repainting and/or Removal & Demolition Supervisor.
                </span>
                   </div>
                </div>
                    <div class="row">
                         <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">MHIC <small>(if applicable)</small></label>

                     <div >
                        <asp:TextBox ID="txtMHICNumber" class="form-control" placeholder="MHIC Number" title="MHIC Number" runat="server"></asp:TextBox> <span class="help-block m-b-none">For more information, contact Maryland Home Improvement Commission at 410-230-6309.</span><br /><span class="help-block m-b-none"><b>Important</b> - This accreditation does not satisfy the EPA Renovation, Repair, and Painting (RRP) Rule. For more information, visit the EPA website at https://www.epa.gov/lead.</span>
                    </div></div></div>
                        <div class="col-lg-6">
                            <p ></p>
                        </div>
                    </div>




                     <div class="col-lg-12">
                <div class="input-group"><div class="input-group-btn">
                     <input type='button' class="btn btn-xs btn-success" value='ADD EMPLOYEE' id='addButtonResidential'>
                        <input type='button' class="btn btn-xs btn-danger" value='REMOVE EMPLOYEE' id='removeButtonResidential'>
                </div></div>
                    </div>
                     <br />
                <br />
                <div id="ResidentialGroup">
                <div id="ResidentialEmp_1" class="row">
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">First Name</label>

                     <div >
                        <asp:TextBox ID="ResidentialEmpFN_1" class="form-control" placeholder="First Name" title="First Name" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                     <div >
                        <asp:TextBox ID="ResidentialEmpLN_1" class="form-control" placeholder="Last Name" title="Last Name" runat="server"></asp:TextBox>
                    </div></div></div>
                    <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label>

                     <div >
                        <asp:TextBox ID="ResidentialAcctId_1" class="form-control" placeholder="Accreditation #" title="Accreditation #" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label>
                           
                     <div >
                         <asp:DropDownList ID="dropIsApplyResidential_1" CssClass="form-control m-b"  ToolTip="Is Applying for Accreditation" runat="server">
                               <asp:ListItem Value="-1">Select One</asp:ListItem>
                             <asp:ListItem Value="0">NO</asp:ListItem>
                             <asp:ListItem Value="1">YES</asp:ListItem>
                        </asp:DropDownList>
                    </div></div></div>
                     
                </div>
                </div>
            </div>
            <div id="divCatSteel" class="alert" style="background-color:#fff; color:#000;">
                   <div class="row">
               <div class="col-lg-12">
                   <h2>
                   Steel Structure
                </h2> <span class="help-block">
                   <b class="text-right">fee:$250.00</b><br /> Add employees who are accredited or are applying to be accredited as a Structural Steel Supervisor.
                </span>
                   </div>
               
                     <div class="col-lg-12">
                <div class="input-group"><div class="input-group-btn">
                     <input type='button' class="btn btn-xs btn-success" value='ADD EMPLOYEE' id='addButtonSteel'>
                        <input type='button' class="btn btn-xs btn-danger" value='REMOVE EMPLOYEE' id='removeButtonSteel'>
                </div></div>
                    </div>
                     </div>
                <br />
                <div id="SteelGroup">
                <div id="SteelEmp_1" class="row">
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">First Name</label>

                     <div >
                        <asp:TextBox ID="SteelEmpFN_1" class="form-control" placeholder="First Name" title="First Name" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                     <div >
                        <asp:TextBox ID="SteelEmpLN_1" class="form-control" placeholder="Last Name" title="Last Name" runat="server"></asp:TextBox>
                    </div></div></div>
                    <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label>

                     <div >
                        <asp:TextBox ID="SteelAcctId_1" class="form-control" placeholder="Accreditation #" title="Accreditation #" runat="server"></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-3">
                        <div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label>
                           
                     <div >
                         <asp:DropDownList ID="dropIsApplySteel_1" CssClass="form-control m-b"  ToolTip="Is Applying for Accreditation" runat="server">
                             <asp:ListItem Value="-1">Select One</asp:ListItem>
                             <asp:ListItem Value="0">NO</asp:ListItem>
                             <asp:ListItem Value="1">YES</asp:ListItem>
             </asp:DropDownList>
                    </div></div></div>
                     
                </div>
                </div>
            </div>
        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:2px !important; padding:1px !important">
            &nbsp;
            </div>
            <div class="alert" style="background-color:#fff; color:#000;">
         <div class="row">
                 <div class="col-lg-6"><h5>Check below if it applies to the contractor.<b>If selected, this application fee is waived</b> </h5></div>
              <div class="col-lg-6">
                  <asp:DropDownList ID="dropWaiverType" CssClass="form-control m-b" onchange="javascript:CheckCategory();"  ToolTip="List Company Publicly" runat="server">
                         <asp:ListItem Value="-1">Select One</asp:ListItem>
                         <asp:ListItem Value="0">State or Local Government</asp:ListItem>
                         <asp:ListItem Value="1">Self-Employed (contractor does not employ or hire others)</asp:ListItem>
                </asp:DropDownList>
             </div>
             </div>
    </div>    

         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">IV. Public Listings</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-10"><h5>Check to be included on the list of accredited Inspection Contractors or Residential, Commercial & Public Buildings Contractors that is made available to the public through mailings & the website.</h5></div>
                 <div class="col-lg-2">
                     <asp:DropDownList ID="dropPublicListing" CssClass="form-control m-b"  ToolTip="List Company Publicly" runat="server">
                         <asp:ListItem Value="-1">Select One</asp:ListItem>
                         <asp:ListItem Value="0">NO</asp:ListItem>
                         <asp:ListItem Value="1">YES</asp:ListItem>
             </asp:DropDownList>
                 </div>
                
             </div>
             </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12"><h5>What region will you serve? Check all applicable</h5></div>
                 </div>
             <br />
             <div class="row">
                     <asp:Panel ID="pnlRegions" runat="server"></asp:Panel>    
             </div>
             </div>
        <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-4"><h5>Name of contact person (if this is left blank, the "Authorized Representative of [Contractor Name]" will be used)</h5></div>
                 <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">First Name</label>

                     <div >
                        <asp:TextBox ID="txtContactFName" class="form-control" placeholder="Contact First Name" title="Contact First Name" runat="server"></asp:TextBox>
                    </div></div></div>
                  <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                     <div >
                        <asp:TextBox ID="txtContactLName" class="form-control" placeholder="Contact Last Name" title="Contact Last Name" runat="server"></asp:TextBox>
                    </div></div></div>
                 </div>
             </div>

        <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">V. Type of Services Offered</h5>
            </div>
         <div class="alert" style="background-color:#fff; color:#000;">
             <div class="row">
                 <div class="col-lg-12"><h5>For Residential, Commercial, & Public Buildings Contractors ONLY - What type of service(s) will you offer? Check all applicable</h5></div>
                 </div>
             <br />
                     <asp:Panel ID="pnlServiceOffered" runat="server"></asp:Panel>    
             </div>
         <div class="alert" style="background-color:#000; color:#fff; text-align:center; height:20px; top:5px;">
             <h5 style="margin:-5px 0">VI. Applicant Statement and Signature</h5>
            </div>
          <div class="alert" style="background-color:#fff; color:#000;">
                <p>This Notice is provided pursuant to 4-501 of the General Provisions Article of the Maryland Code. The personal information requested on this form is intended to be used in processing your application. Failure to provide the information requested may result in your application not being processed. You have the right to inspect, amend, or correct this form. The Maryland Department of the Environment ("Department") is a public agency and subject to the Maryland Public Information Act(Md. Code Ann., General Provisions 4-101. et seq). This form may be made available on the internet via the Department's website and is subject to inspection or copying , in whole or in part, by the public and other governmental agencies, if not protected by federal or State law.</p><br />
                     <p>As per Environment Article 1-203 and Family Law Article 10-119.3 of Maryland before any license or permit may be issued or renewed, the issuing authority shall verify through the Office of the Comptroller and the Maryland Child Support Enforcement Administration that the applicant has no outstanding taxes, unemployment insurance contributions or child support.</p><br />
                     <p>I hereby request that the above contractor be accredited as a Lead Paint Abatement Services Contractor in the State of Maryland. I certify that, for the purpose of performing lead paint services, the aforementioned will only employ, hire or contract with individuals or companies that are qualified under Code of Maryland Regulations (COMAR) 26.16.01. I certify that my company and its employees shall perform work practices according to COMAR 26.16.01 and/or 26.02.07. If seeking accreditation as a Lead Paint Inspection Contractor; I certify that any and all unused inspection certificates will be returned to the Department within five(5) days should the Inspection Coontractor cease to perform lead paint inspection services. I certify that work performed and certificates issued by my company and its employees will satisfy the requirements of Environment Article 6-8 and COMAR 26.16.01 through 26.16.05</p>
                 </div>
                

        <div class="alert" style="background-color:#fff; color:#000;">
                <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-12 control-label">First Name</label>

                    <div >
                        <asp:TextBox ID="txtAuthRepContFName" class="form-control" placeholder="First Name"  title="First Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Authorized Representative of Contractor First Name)</span>
                    </div></div></div>
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                    <div >
                        <asp:TextBox ID="txtAuthRepContLName" class="form-control" placeholder="Last Name" title="Last Name" runat="server" required></asp:TextBox><span class="help-block m-b-none">(Authorized Representative of Contractor Last Name)</span>
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
            $("#CPMain_txtSDATNum").inputmask({
                mask: '999999',
                placeholder: '999999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtFax").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
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
            $("#CPMain_txtEIN").inputmask({
                mask: '9999999999',
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

             
		var counter = 2;
	    $("#addButtonInspection").click(function () {
				
			if(counter>10){
		        alert("Only 10 textboxes allow");
		        return false;
		    }   
			
            var newTextBoxDiv = $(document.createElement('div')).attr("id", 'InspectorEmp_' + counter).attr("class", 'row');    
                newTextBoxDiv.after().html('<div class=col-lg-3><div class=form-group><label class=col-sm-10 control-label>First Name</label><div>' +
				'<input name="ctl00$CPMain$InspectorEmpFN_' + counter + 
                    '" type="text" id="CPMain_InspectorEmpFN_' + counter +
                    '" class="form-control" placeholder="First Name" title="First Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Last Name</label><div>' +
                    '<input name="ctl00$CPMain$InspectorEmpLN_' + counter + 
                    '" type="text" id="CPMain_InspectorEmpLN_' + counter +
                    '" class="form-control" placeholder="Last Name" title="Last Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label><div>' +
                    ' <input name="ctl00$CPMain$InspectorAcctId_' + counter +
                    '" type="text" id="CPMain_InspectorAcctId_' + counter +
                    '" class="form-control"  placeholder="Accreditation #" title = "Accreditation #"></div ></div ></div >' + 
                    '<div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label><div>' +
                    '<select name="ctl00$CPMain$dropIsApply_' + counter + 
                    '" id="CPMain_dropIsApplyInspector_' + counter +
                    'title="Is Applying for Accreditation" class="form-control m-b"><option value="-1">Select One</option><option value="0">NO</option><option value="1">YES</option></select></div></div></div></div>');
            
			newTextBoxDiv.appendTo("#InspectionGroup");
				
		    counter++;
	    });
	    $("#removeButtonInspection").click(function () {
		    if(counter == 2){
		        return false;
		    }   
	        counter--;
			
	        $("#InspectorEmp_" + counter).remove();
		});
		//*****************************************************
        $("#addButtonSteel").click(function () {
				
			if(counter>10){
		        alert("Only 10 textboxes allow");
		        return false;
		    }   
			
            var newTextBoxDivSteel = $(document.createElement('div')).attr("id", 'SteelEmp_' + counter).attr("class", 'row');    
                newTextBoxDivSteel.after().html('<div class=col-lg-3><div class=form-group><label class=col-sm-10 control-label>First Name</label><div>' +
				'<input name="ctl00$CPMain$SteelEmpFN_' + counter + 
                    '" type="text" id="CPMain_SteelEmpFN_' + counter +
                    '" class="form-control" placeholder="First Name" title="First Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Last Name</label><div>' +
                    '<input name="ctl00$CPMain$SteelEmpLN_' + counter + 
                    '" type="text" id="CPMain_SteelEmpLN_' + counter +
                    '" class="form-control" placeholder="Last Name" title="Last Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label><div>' +
                    ' <input name="ctl00$CPMain$SteelAcctId_' + counter +
                    '" type="text" id="CPMain_SteelAcctId_' + counter +
                    '" class="form-control"  placeholder="Accreditation #" title = "Accreditation #"></div ></div ></div >' + 
                    '  <div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label><div>' +
                    '<select name="ctl00$CPMain$dropIsApplySteel_' + counter + 
                    '" id="CPMain_dropIsApplySteel_' + counter +
                    'title="Is Applying for Accreditation" class="form-control m-b"><option value="-1">Select One</option><option value="0">NO</option><option value="1">YES</option></select></div></div></div></div>');
            
			newTextBoxDivSteel.appendTo("#SteelGroup");
				
		    counter++;
	    });
	    $("#removeButtonSteel").click(function () {
		    if(counter == 2){
		        return false;
		    }   
	        counter--;
			
	        $("#SteelEmp_" + counter).remove();
            });
       //******************************************************
        $("#addButtonResidential").click(function () {
				
			if(counter>10){
		        alert("Only 10 textboxes allow");
		        return false;
		    }   
			
            var newTextBoxDivResidential = $(document.createElement('div')).attr("id", 'ResidentialEmp_' + counter).attr("class", 'row');    
                newTextBoxDivResidential.after().html('<div class=col-lg-3><div class=form-group><label class=col-sm-10 control-label>First Name</label><div>' +
				'<input name="ctl00$CPMain$ResidentialEmpFN_' + counter + 
                    '" type="text" id="CPMain_ResidentialEmpFN_' + counter +
                    '" class="form-control" placeholder="First Name" title="First Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Last Name</label><div>' +
                    '<input name="ctl00$CPMain$ResidentialEmpLN_' + counter + 
                    '" type="text" id="CPMain_ResidentialEmpLN_' + counter +
                    '" class="form-control" placeholder="Last Name" title="Last Name"></div></div></div><div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Accreditation #</label><div>' +
                    ' <input name="ctl00$CPMain$ResidentialAcctId_' + counter +
                    '" type="text" id="CPMain_ResidentialAcctId_' + counter +
                    '" class="form-control"  placeholder="Accreditation #" title = "Accreditation #"></div ></div ></div >' + 
                    ' <div class="col-lg-3"><div class="form-group"><label class="col-sm-10 control-label">Is Applying for Accreditation?</label><div>' +
                    '<select name="ctl00$CPMain$dropIsApply_' + counter + 
                    '" id="CPMain_dropIsApplyResidential_' + counter +
                    'title="Is Applying for Accreditation" class="form-control m-b"><option value="-1">Select One</option><option value="0">NO</option><option value="1">YES</option></select></div></div></div></div>');
            
			newTextBoxDivResidential.appendTo("#ResidentialGroup");
				
		    counter++;
	    });
	    $("#removeButtonResidential").click(function () {
		    if(counter == 2){
		        return false;
		    }   
	        counter--;
			
	        $("#ResidentialEmp_" + counter).remove();
		});

		$("#getButtonValue").click(function () {
		
			var msg = '';
			for(i=1; i<counter; i++){
				msg += "\n Textbox #" + i + " : " + $('#textbox' + i).val();
			}
		   	alert(msg);
            });

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
        function CheckCategory() {

            var WaiverType = $('[id*=CPMain_dropWaiverType]').val();
            
            if (WaiverType > -1)
            {
                //Making default to 0
               $('[id*=CPMain_dropCategory]').val('0').attr('selected', 'true');
               $('[id*=CPMain_dropCategory]').attr('disabled', true);

                //Hiding all
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
               
               $('[id*=txtMHICNumber]').val('');
               
                for (i = 0; i < 9; i++)
                {
                    $("#ResidentialEmp_" + i).remove();
                    $("#SteelEmp_" + i).remove();
                    $("#InspectorEmp_" + i).remove();
                }
                $("#addButtonResidential").click();
                $("#addButtonSteel").click();
                $("#addButtonInspection").click();

            }
            else
            {
                $('[id*=CPMain_dropCategory]').removeAttr('disabled');
                $('[id*=CPMain_dropCategory] [value=NA]').attr('selected', 'true');
            }
        }
        function CategoryIs() {
            var SelectedVal = $('[id*=CPMain_dropCategory]').val();
           
            if (SelectedVal == '10') {
                $('[id*=divCatInspection]').show();
                $('[id*=divCatResidential]').hide();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '11') {
                $('[id*=divCatInspection]').hide();
                $('[id*=divCatResidential]').show();
                $('[id*=divCatSteel]').hide();
            }
            else if (SelectedVal == '12') {
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
        function CheckMailingAddress() {
            var IPublicList = $('[id*=dropPublicList]').val();
            var MailingAdd = $('[id*=txtAddress_2]').val();
            var CityAdd = $('[id*=txtCity_2]').val();
            var StateAdd = $('[id*=txtState_2]').val();
            var ZipCodeAdd = $('[id*=txtZipcode_2]').val();

            if (IPublicList > -1) {
                if (MailingAdd.length == 0) {
                    alert('Please, enter Mailing address before selecting Mailing Address as a Public listings Address!');
                    $('[id*=dropPublicList]').val('1').attr('selected', 'true');
                } else
                {
                    if (CityAdd.length == 0) {
                        alert('Mailing Address City is missing!');
                        $('[id*=dropPublicList]').val('1').attr('selected', 'true');
                    }
                    if (StateAdd.length == 0) {
                        alert('Mailing Address State is missing!');
                        $('[id*=dropPublicList]').val('1').attr('selected', 'true');
                    }
                    if (ZipCodeAdd.length == 0) {
                        alert('Mailing Address Zip Code is missing!');
                        $('[id*=dropPublicList]').val('1').attr('selected', 'true');
                    }
                }
            }
        }
        function formIsValid() {
            var IPublicList = $('[id*=dropPublicList]').val();
            var IAgree = $('[id*=chkIAgree]').is(':checked');
            var CatIs = $('[id*=CPMain_dropCategory]').val();
            var ChkRenewal = $('[id*=CPMain_dropIsRenewal]').val();
            var IsWaiver = $('[id*=CPMain_dropWaiverType]').val();

            if (IPublicList == -1) {
                alert('Please, Select Which Addresses should be listed on public listings?');
                return false;
            }

             if (ChkRenewal == -1) {
                alert('Please, Select either NO or YES from Section III. Have you held an accreditation with the same name and category in the past with the state of Maryland?');
                return false;
            }

            if ((IsWaiver == -1) && CatIs == 0) {
                alert('Please, Select a Category or select State or Local government or Self-Employeed.');
                return false;
            }

            if (!IAgree) {
                alert('Please, Click on I Agree Statement before submitting your application!');
                return false;
            }
    

            }
        </script>
</asp:Content>

