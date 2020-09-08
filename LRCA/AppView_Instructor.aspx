<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppView_Instructor.aspx.cs" Inherits="LRCA.AppView_Instructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          <asp:Label ID="lblInstructorApp" runat="server" ></asp:Label></span>         
            </h2>
            <small>Instructor <asp:Label ID="lblInstructorAss" runat="server" ></asp:Label></span>.</small>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
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
                       Instructor Information
                        </a>
                    </div>
                              <div class="panel-body">

                <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">First Name</label>

                    <div class="col-sm-10">
                     <asp:Label ID="lblFName" class="form-control"  title="Instructor First Name" runat="server" ></asp:Label>
                    </div></div></div>

                        <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Last Name</label>

                    <div class="col-sm-10">
                     <asp:Label ID="lblLName" class="form-control" title="Instructor Last Name" runat="server" ></asp:Label>
                    </div></div></div>


                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Training Provider</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblTP" class="form-control" title="Name of Accredited Training Provider" runat="server" ></asp:Label>
                    </div></div></div>
                 </div>
                 <br />
                <div class="row">
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Email</label>
                            
                    <div class="col-sm-10">
                        <asp:Label ID="lblTPEmail" class="form-control" title="Training Provider Email" runat="server" ></asp:Label>
                    </div></div></div>

                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Phone</label>
                            
                    <div class="col-sm-10">
               <asp:Label ID="lblTPPhone" class="form-control" title="Training Provider Phone" runat="server" ></asp:Label>
                    </div></div></div>
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Mobile</label>
                            
                    <div class="col-sm-10">
               <asp:Label ID="lblTPMobile" class="form-control" title="Training Provider Mobile" runat="server" ></asp:Label>
                    </div></div></div>
                    </div>
                <br />
                
            
                 <div class="row">
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Category</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblCategory" class="form-control" title="Instructor Specialization Category" runat="server" ></asp:Label>
                    </div></div></div>
             <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Instructor Accreditation Number</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblInsAccId" class="form-control" title="Instructor Accreditation Number" runat="server" ></asp:Label>
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Accreditation Expiration Date</label>

                     <div class="col-sm-10">
                        <asp:Label ID="lblAccdExpireDate" class="form-control" title="Instructor Accreditation Expiration Date" runat="server" ></asp:Label>
                    </div></div></div>
                     </div>

      

        </div>
    </div></div></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
  
</asp:Content>
