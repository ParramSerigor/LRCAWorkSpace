<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppView_Cont.aspx.cs" Inherits="LRCA.AppView_Cont" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          <asp:Label ID="lblContractorApp" runat="server" ></asp:Label></span>         
            </h2>
            <small>Contractor application to get an Accreditation in <asp:Label ID="lblCourseName" runat="server" ></asp:Label>.</small>
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
   
       <div class="row">
             <div class="col-lg-12">
           
                 <div class="row">
                      <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-2 control-label">Company Name</label>

                    <div class="col-sm-12">
                        <asp:Label ID="lblName" runat="server" class="form-control"></asp:Label>
                    </div></div></div>
                 </div>
                  <br />
                 <div class="row">
                      <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">SDAT</label>

                    <div class="col-sm-10">
                        <asp:Label ID="lblSDATNum" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>
                          
                          
                     <div class="col-lg-4">
                      <div class="form-group"><label class="col-sm-10 control-label">EIN</label>

                    <div class="col-sm-10">
                        <asp:Label ID="lblEIN" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>

                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">MHIC</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblMHICNumber" class="form-control"  runat="server"></asp:Label>
                    </div></div></div>

                     </div>
                <br />
                <div class="Row">
                     <div class="col-lg-4">
                          <div class="form-group"><label class="col-sm-10 control-label">Course</label>

                     <div class="col-sm-10">
                              <asp:DropDownList ID="dropCategory" CssClass="form-control m-b" Enabled="false" ToolTip="Courses" runat="server"></asp:DropDownList>

                     </div>
                    </div>
                         </div>

                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Active ACRED ID</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblACCID" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>

                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation Expiration Date</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAccreditationExpirationDate" class="form-control"  runat="server" ></asp:Label>
                    </div></div></div>

                </div>
                <br />
                 </div>
               
               
            </div>

                  <div class="row">
                 <div class="col-lg-12">
             
                <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Address</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAddress_1" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>
                          
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Address Cont.</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAddress_2" class="form-control" runat="server"></asp:Label>
                    </div></div></div>
                          
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblCity" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>

                          
                </div>
                <br />
                 <div class="row">
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">County</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblCounty" class="form-control" runat="server"></asp:Label>
                    </div></div></div>

                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblState" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>
                          
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblZipCode" class="form-control" runat="server"></asp:Label>
                    </div></div></div>
                          
                </div>
                <br />
                 <div class="row">
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Phone</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblPhone" class="form-control"  runat="server"></asp:Label>
                    </div></div></div>

                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Mobile</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblMobile" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>
                          
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Web Site</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblWebSite" class="form-control" runat="server" ></asp:Label>
                    </div></div></div>          
                </div>
                <br />
                 <div class="row">
                   <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Email Address</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblEmailAddress" class="form-control"  runat="server"></asp:Label>
                    </div></div></div>

                  
                           <div class="col-lg-4">
                          <div class="checkbox-primary form-control m-b">
                             <asp:CheckBox ID="chkFeeStatus" Enabled="false" runat="server" />
                                <label for="chkFeeStatus">
                                    Fee Status is Upto-date
                                </label>
                            </div>
                                        </div>

                     <div class="col-lg-4">
                          <div class="checkbox-primary form-control m-b">
                            <asp:CheckBox ID="chkPublishOnMDEWebsite" Enabled="false" runat="server" />
                                <label for="chkPublishOnMDEWebsite">
                                    Is Publish On MDE Website
                                </label>
                            </div>
                                        </div>
                    
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

