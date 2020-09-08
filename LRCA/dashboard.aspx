<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="LRCA.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="pnlAllRole" runat="server"></asp:Panel>
</div>
         </div>
    
    
     <!-- View Video modal -->
<div class="modal fade" id="modalVideo"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
									×
								</button>
								<h4 id="H1" class="modal-title"><div id="TitleIn"></div></h4>
							</div>
							<div class="modal-body">
                                <div id="bookId" align="left"></div>
                                <asp:TextBox ID="txtNoteId" Width="1px" Height="1px" style="position:absolute; top:-122222px" runat="server"></asp:TextBox>
							</div>
							<div class="modal-footer">
                                
								<button data-dismiss="modal" class="btn btn-xs btn-default" type="button">
									Cancel
								</button>
								
							</div>
						</div><!-- /.modal-content -->
					</div><!-- /.modal-dialog -->
				</div>

<!-- View Video modal -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
   <script>
		     
                
                
		       
		       
		    function autoPlayYouTubeModal() {
		        var trigger = $("body").find('[data-toggle="modal"]');
		        trigger.click(function () {
		            var theModal = $(this).data("target"),
                        videoSRC = $(this).attr("data-theVideo"),
                        videoSRCauto = videoSRC + "?autoplay=1";
		            $(theModal + ' iframe').attr('src', videoSRCauto);
		            $(theModal + ' button.close').click(function () {
		                $(theModal + ' iframe').attr('src', videoSRC);
		            });
		            $('.modal').click(function () {
		                $(theModal + ' iframe').attr('src', videoSRC);
		            });
		        });
		    }
	</script>
    
</asp:Content>