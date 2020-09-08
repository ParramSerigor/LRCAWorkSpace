<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppTrainee.aspx.cs" Inherits="LRCA.AppTrainee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Schedule a Class</span>         
            </h2>
            <small>Please, fill out the form below and click on submit button to schedule a Class.</small>
        </div>
          <div class="input-group"><div class="input-group-btn"><a href="#" onclick="return history.back();" class="btn btn-success">Back</a></div><div class="alert alert-success" style="padding:8px !important;">&nbsp;</div></div>
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
                       Search Classes
                        </a>
                    </div>
                   
            <div class="panel-body">
                 <div class="row">
                     <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Courses</label>
                    <div >
                        <asp:DropDownList ID="dropCourses" CssClass="form-control m-b" ToolTip="Courses" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select a Course from the dropdown list.</span>
                    </div></div></div>
                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Title</label>

                    <div >
                        <asp:TextBox ID="txtCTitle" class="form-control" placeholder="Class Title" title="Class Title" runat="server" required></asp:TextBox>
                    </div></div></div>
                 </div>
                 </div>
                     <div class="panel-footer">
                        <asp:Button ID="btnAddClass" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Search" />
                    </div>
          </div></div></div>
    <br />
     <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Scheduled Classes
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Title </th>
                                                    <th>Start - End Dates</th>
                                                    <th>Language</th>
                                                    <th>Registration Limit</th>
                                                    <th>Minimum Enrollment</th>
                                                    <th>Location</th>
                                                    <th>Date Created</th>
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
