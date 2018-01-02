<%@ Page Title="幸運號碼猜猜看" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="com.oli365.prize._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="text-align:center;font-size:200%">
        開獎號碼
        </div>
   <div >
       <table width="100%">
           <tr>
               <td valign="top">
                    <div style="font-size:200%;margin-top:5%;margin:0 auto;width:50%">
       <b>今彩539</b>
    </div>
    <div  style="margin:0 auto;">
        <asp:DataList ID="gv_lotto539" runat="server" DataKeyField="PERIOD" OnItemDataBound="gv_lotto539_ItemDataBound">
            <ItemTemplate>
                <div style="font-size:150%"><%#DataBinder.Eval(Container.DataItem,"LOTTERY_DAY") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期
                    【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>】
                </div>
                    <div style="font-size:100%">
                       <asp:DataList ID="dl" runat="server" >
                           
                           <ItemTemplate>
                              <%#DataBinder.Eval(Container.DataItem,"NICK_NAME") %><%#DataBinder.Eval(Container.DataItem,"CAL_NAME") %>預測號碼【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>】對中<%#DataBinder.Eval(Container.DataItem,"MATCH_NUM") %>個號碼
                           </ItemTemplate>
                       </asp:DataList>
                   </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
 
              


               </td>
               <td valign="top"> <div style="font-size:200%;margin-top:5%;margin:0 auto;width:50%">
       <b>暗彩539</b>
    </div>
    <div  style="margin:0 auto;">
        <asp:DataList ID="dv_lotto539" runat="server" OnItemDataBound="dv_lotto539_ItemDataBound" DataKeyField="PERIOD">
            <ItemTemplate>
                <div style="font-size:150%"><%#DataBinder.Eval(Container.DataItem,"LOTTERY_DAY") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期

                    【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>】
                </div>
                 <div style="font-size:100%">
                       <asp:DataList ID="dvlist" runat="server" >
                           <ItemTemplate>
                              <%#DataBinder.Eval(Container.DataItem,"NICK_NAME") %><%#DataBinder.Eval(Container.DataItem,"CAL_NAME") %>預測號碼【 <%#DataBinder.Eval(Container.DataItem,"NUMS") %>對中<%#DataBinder.Eval(Container.DataItem,"MATCH_NUM") %>個號碼
                           </ItemTemplate>
                       </asp:DataList>
                   </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
 
                 


               </td>
               </tr>
           <tr>


               <td>

                    <div style="font-size:200%;margin-top:5%;margin:0 auto;width:50%">
        <b>大樂透</b>
    </div>
    <div>
        <asp:DataList ID="gv_lotto649" runat="server">
            <ItemTemplate>
                 <div style="font-size:150%"><%#DataBinder.Eval(Container.DataItem,"LOTTERY_DATE") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期

                     【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>,<%#DataBinder.Eval(Container.DataItem,"NUM6") %>】
                 </div>
                
            </ItemTemplate>
        </asp:DataList>
    </div>

                    <div style="font-size:80%">

                       <asp:DataList ID="dl_lotto649" runat="server">
                           <ItemTemplate>
                              <%#DataBinder.Eval(Container.DataItem,"NICK_NAME") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期，<%#DataBinder.Eval(Container.DataItem,"CAL_NAME") %>預測號碼【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>,<%#DataBinder.Eval(Container.DataItem,"NUM6") %>】對中<%#DataBinder.Eval(Container.DataItem,"MATCH_NUM") %>個號碼
                           </ItemTemplate>
                       </asp:DataList>
                   </div>

               </td>
                <td>

                      <div style="font-size:200%;margin-top:5%;margin:0 auto;width:50%">
       <b>威力彩</b>
    </div>
    <div>
        <asp:DataList ID="gv_superlotto" runat="server">
            <ItemTemplate>
                  <div style="font-size:150%;width:100%;text-align:center"><%#DataBinder.Eval(Container.DataItem,"LOTTERY_DATE") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期</div>
                      <div  style="font-size:150%;width:100%;text-align:center"> 【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>,<%#DataBinder.Eval(Container.DataItem,"NUM6") %>】特別號：【<%#DataBinder.Eval(Container.DataItem,"ESP_NUM") %>】</div>

                  
               

            </ItemTemplate>

        </asp:DataList>
    </div>
                     <div style="font-size:80%">

                       <asp:DataList ID="dl_superlotto" runat="server">
                           <ItemTemplate>
                               <%#DataBinder.Eval(Container.DataItem,"NICK_NAME") %>第<%#DataBinder.Eval(Container.DataItem,"PERIOD") %>期，<%#DataBinder.Eval(Container.DataItem,"CAL_NAME") %>預測號碼【 <%#DataBinder.Eval(Container.DataItem,"NUM1") %>,<%#DataBinder.Eval(Container.DataItem,"NUM2") %>,<%#DataBinder.Eval(Container.DataItem,"NUM3") %>,<%#DataBinder.Eval(Container.DataItem,"NUM4") %>,<%#DataBinder.Eval(Container.DataItem,"NUM5") %>,<%#DataBinder.Eval(Container.DataItem,"NUM6") %>】對中<%#DataBinder.Eval(Container.DataItem,"MATCH_NUM") %>個號碼，及特別號<%# DataBinder.Eval(Container.DataItem, "IS_ESP") %>
                           </ItemTemplate>
                       </asp:DataList>
                   </div>

                </td>
           </tr>
       </table>
   

   

  

       </div>
</asp:Content>
