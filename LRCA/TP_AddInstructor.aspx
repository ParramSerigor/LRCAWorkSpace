<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TP_AddInstructor.aspx.cs" Inherits="LRCA.TP_AddInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
      <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Add Instructor</span>         
            </h2>
            <small>Add Instructor to the Training Provider </small>
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
                       Add Instructors
                        </a>
                    </div>
                              <div class="panel-body">
       <div class="row">
                 <div class="col-lg-12">
                <div class="hpanel">
                     <div class="panel-body">
                         <div class="input-group">
                             <asp:TextBox ID="txtAcctNumber" CssClass="form-control" placeholder="Search Instructor by Accreditation Number ... " runat="server" required></asp:TextBox>
                                <div class="input-group-btn">
                                    <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Search" />
                                </div>
                            </div>

                </div>
                </div>
                      <table id="example_" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
                                                    <th>Full Name</th>
													<th>Email </th>
                                                    <th>Accreditation #</th>
                                                    <th>Expiration Date</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlInstructors" runat="server"></asp:Panel>
											</tbody>
                                     </table>
           </div>
 
               </div>
</div></div></div></div>
            </div>

     <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Instructors
                            </a>
                        
                    </div>
                   
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
                                                    <th>Full Name</th>
													<th>Email </th>
                                                    <th>Training Provider </th>
                                                    <th>Accreditated In</th>
                                                    <th>Accreditation #</th>
                                                    
                                                    <th>Account Status</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlVideos" runat="server"></asp:Panel>
											</tbody>
                                     </table>
                </div>
        </div>
    </div>     
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
   <script type="text/javascript">
        $(document).ready(function () {
            $(":input").inputmask();

            $("#CPMain_txtAcctNumber").inputmask({
                mask: '9999999',
                placeholder: '9999999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            
         $("#form1").validate({
             rules: {
                ctl00$CPMain$txtAcctNumber: {
					required: true,
                    minlength: 0,
                    maxlength: 7
                 }
			},
             messages: {
                ctl00$CPMain$txtCost: {
                    minlength: "Please enter valid Accreditation Number!",
                    maxlength: "Please enter valid Accreditation Number!"
                 }
			}
		});
        });
       
        </script>
</asp:Content>
