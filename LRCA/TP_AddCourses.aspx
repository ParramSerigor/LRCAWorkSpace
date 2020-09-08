<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TP_AddCourses.aspx.cs" Inherits="LRCA.TP_AddCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Create a Course</span>         
            </h2>
            <small>Please, fill out the form below and click on submit button to create a Course.</small>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   
    <div class="hpanel "  >
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-down"></i></a>
                </div>
                 <a class="showhide"><i class="fa fa-chevron-down"></i> Click here to Add Course</a>
            </div>

    
       <div class="row">
            <div class="col-lg-12">
                <div class="hpanel collapsed">
                   
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Training Provider</label>

                    
                        <asp:DropDownList ID="dropTPs" CssClass="form-control m-b" ToolTip="Accreditated Training Providers" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select Accreditated Training Provider from the dropdown list.</span>
                    </div></div>
                </div>
                 <div class="row">
                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Title</label>

                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCTitle" class="form-control" placeholder="Course Title" title="Course Title" runat="server" required></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Course Category</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropCourseCat" CssClass="form-control m-b" ToolTip="Course Category" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select Course Category from the dropdown list.</span>
                    </div></div></div>
                 </div>
                <br />
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Course Description</label>
                            
                    <div class="col-sm-10">
               <asp:TextBox ID="txtCDesc" class="form-control" placeholder="Course Description"   title="Course Description" runat="server" ></asp:TextBox>
                    </div></div></div>
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">InstructionLanguage</label>
                            
                    <div class="col-sm-10">
               <asp:DropDownList ID="dropLanguage" CssClass="form-control m-b" ToolTip="Course Language" runat="server">
                  <asp:ListItem Selected="True" Value="English"> English </asp:ListItem>
                   <asp:ListItem Value="Spanish"> Spanish </asp:ListItem>
               </asp:DropDownList>
                    </div></div></div>
                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Course Duration</label>
                          
                    <div class="col-sm-10">
                 <asp:DropDownList ID="dropDuration" CssClass="form-control m-b" ToolTip="Course Duration" runat="server">
                                <asp:ListItem Selected="True" Value="1"> 1-Day </asp:ListItem>
                                <asp:ListItem  Value="2"> 2-Days </asp:ListItem>
                                <asp:ListItem  Value="3"> 3-Days </asp:ListItem>
                                <asp:ListItem Value="4"> 4-Days </asp:ListItem>
                                <asp:ListItem  Value="5"> 5-Days </asp:ListItem>
                                </asp:DropDownList>
                    </div></div></div>
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Attendance Required</label>
                            
                    <div class="col-sm-10">
                         <asp:DropDownList ID="dropAttendanceReq" CssClass="form-control m-b" ToolTip="Attendance Required" runat="server">
                          <asp:ListItem Selected="True" Value="1"> YES </asp:ListItem>
                           <asp:ListItem Value="0"> NO </asp:ListItem>
                       </asp:DropDownList>
                    </div></div></div>
                </div>
                <br />
                 <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Passing Percentage</label>
                            
                    <div class="col-sm-10">
               <asp:DropDownList ID="dropPassPercent" CssClass="form-control m-b" ToolTip="Course Language" runat="server">
                                <asp:ListItem  Value="10"> 10% </asp:ListItem>
                                <asp:ListItem  Value="20"> 20% </asp:ListItem>
                                <asp:ListItem  Value="30"> 30% </asp:ListItem>
                                <asp:ListItem  Value="40"> 40% </asp:ListItem>
                                <asp:ListItem  Value="50"> 50% </asp:ListItem>
                                <asp:ListItem  Value="60"> 60% </asp:ListItem>
                                <asp:ListItem Selected="True"  Value="70"> 70% </asp:ListItem>
                                <asp:ListItem  Value="80"> 80% </asp:ListItem>
                                <asp:ListItem  Value="90"> 90% </asp:ListItem>
                                <asp:ListItem  Value="100"> 100% </asp:ListItem>
                                </asp:DropDownList>
                    </div></div></div>
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Initial Or Renewal</label>
                            
                    <div class="col-sm-10">
                         <asp:DropDownList ID="dropInitRenew" CssClass="form-control m-b" ToolTip="Initial Or Renewal" runat="server">
                          <asp:ListItem Selected="True" Value="1"> Initial </asp:ListItem>
                           <asp:ListItem Value="0"> Renewal </asp:ListItem>
                       </asp:DropDownList>
                    </div></div></div>
                </div>
               </div>
                    <div class="panel-footer">
                        <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Submit" />
                    </div>
                 </div>
            </div>
    </div>
        </div>
    <br />
     <div class="row">
        <div class="col-lg-12">
                <div class="hpanel ">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Courses
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Title </th>
                                                    <th>Category</th>
                                                    <th>Language</th>
                                                    <th>Duration</th>
                                                    <th>Attendence Required</th>
                                                    <th>Passing Percentage</th>
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
