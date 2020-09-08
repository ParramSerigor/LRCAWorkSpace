<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppView_TP.aspx.cs" Inherits="LRCA.AppView_TP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          <asp:Label ID="lblContractorApp" runat="server" ></asp:Label></span>         
            </h2>
            <small>Training Provider application for registeration.</small>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>

    <asp:Label ID="lblerror" runat="server" ></asp:Label>

<div class="hpanel collapsed"  >
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-down"></i></a>
                </div>
                 <a class="showhide"><i class="fa fa-chevron-down"></i> Click here to view application</a>
            </div>
            <div class="panel-body">
    <h4 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
                          Training Provider Information</span>         
                        </h4>
       <div class="row">
            <div class="col-lg-12">
              
           
                 <div class="row">
                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Name</label>

                    <div class="col-sm-10">
               <asp:Label ID="lblTPName" class="form-control" title="Training Provider Name" runat="server" ></asp:Label>
                    </div></div></div>
                     <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Contractor</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblContractor" class="form-control" title="Contractor Name" runat="server" ></asp:Label>
                    </div></div></div>
                 </div>
                <br />
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Phone</label>
                            
                    <div class="col-sm-10">
               <asp:Label ID="lblTPPhone" class="form-control"  title="Training Provider Phone" runat="server" ></asp:Label>
                    </div></div></div>
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Mobile</label>
                            
                    <div class="col-sm-10">
               <asp:Label ID="lblTPMobile" class="form-control"  title="Training Provider Mobile" runat="server" ></asp:Label>
                    </div></div></div>
                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Website</label>
                            
                    <div class="col-sm-10">
               <asp:Label ID="lblTPWebsite" class="form-control" title="Training Provider WebSite" runat="server"></asp:Label>
                    </div></div></div>
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Email</label>
                            
                    <div class="col-sm-10">
                        <asp:Label ID="lblTPEmail" class="form-control"  title="Training Provider Email" runat="server" ></asp:Label>
                    </div></div></div>
                </div>
 
                <br />
          <h4 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
                          Instructor Information</span>         
                        </h4>
                 <div class="row">
             <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Instructor Name</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblInstructorName" class="form-control"  title="Instructor Name" runat="server" ></asp:Label><span class="help-block m-b-none">Enter an Accredited Instructor Name.</span>
                    </div></div></div>
             <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Instructor Accreditation Number</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblInsAccId" class="form-control"  title="Instructor Accreditation Number" runat="server" ></asp:Label><span class="help-block m-b-none">Enter an Instructor's Accreditation Number.</span>
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation Expiration Date</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAccdExpireDate" class="form-control"  title="Instructor Accreditation Expiration Date" runat="server" ></asp:Label><span class="help-block m-b-none">Enter an Instructor's Accreditation Expiration Date.</span>
                    </div></div></div>
                     </div>
                 
       
                <br />

     <h4 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
                          Facility Address</span>         
                        </h4>
          
                <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Address</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAddress_1" class="form-control"  title="Address line 1" runat="server" ></asp:Label>
                    </div></div></div>
                          
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Address Cont.</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAddress_2" class="form-control"  title="Address line 2" runat="server"></asp:Label>
                    </div></div></div>
                          
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblCity" class="form-control"  title="City" runat="server" ></asp:Label>
                    </div></div></div>

                          
                </div>
                <br />
                 <div class="row">
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">County</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblCounty" class="form-control" title="County" runat="server"></asp:Label> 
                    </div></div></div>

                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblState" class="form-control"  title="State" runat="server" ></asp:Label> 
                    </div></div></div>
                          
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblZipCode" class="form-control" title="Zip Code" runat="server" ></asp:Label>
                    </div></div></div>
                          
                </div>
           
            </div>
    </div>
      
               </div>
    </div>

    <div class="row">
        <div class="col-md-8">
        <div class="hpanel">
                <div class="v-timeline vertical-container animate-panel" data-child="vertical-timeline-block" data-delay="1">
                    <div class="vertical-timeline-block" style="">
                        <div class="vertical-timeline-icon navy-bg">
                            <i class="fa fa-calendar"></i>
                        </div>
                        <div class="vertical-timeline-content">
                            <div class="p-sm">
                                <span class="vertical-date pull-right"> Saturday <br> <small>12:17:43 PM</small> </span>

                                <h2 class="text-success">Application submitted successfully!</h2>
                                <p>Currently, your application is in a review process. 
                                </p>
                            </div>
                        </div>
                    </div>
                </div>           
        </div>
    </div>
        <div class="col-md-4">
            <h4 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
              File REPOSITORY
            </h4>
             <div class="hpanel">
        <div class="panel-body">
            No files needed!
            
        </div>
           
    </div>
            </div>
    </div>
    



        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
  
</asp:Content>
