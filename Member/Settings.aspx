<%@ Page Title="參數設定" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="com.oli365.prize.Member.LevelSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .td_title {
            text-align:right;
            width:40%;
        }

        .td_value {
            text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main" style="width:70%;margin:0 auto">

        <div  style="text-align:center"><H3><b>參數設定</b></H3></div>
      

            <div  style="text-align:center">
                <div>
                <table width="100%" border="1">
                    <tr>
                        <th  class="td_title">Email通知預測與對獎結果：</th>
                        <td class="td_value">
                            <asp:RadioButtonList ID="rdo_issendmail" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="1" Text="是" />
                                <asp:ListItem Value="0" Text="否" />
                                
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                       <th colspan="2">今彩539</th>
                    </tr>
                    <tr>
                        <th class="td_title">啟用狀態：</th>
                        <td class="td_value">
                            <asp:CheckBox ID="chk_l539_status" runat="server" Text="啟用" /></td>
                    </tr>
                    <tr>
                        <th class="td_title">預測產生組數：</th>
                        <td class="td_value">
                            <asp:DropDownList ID="drp_lotto539amount" runat="server">
                                
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6組"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7組"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8組"></asp:ListItem>
                                <asp:ListItem Value="9" Text="9組"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10組"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <th class="td_title">分析歷史來源筆數：</th>
                        <td class="td_value">
                            <asp:DropDownList ID="drp_l539_his_nums" runat="server">
                                
                                <asp:ListItem Value="30" Text="30筆"></asp:ListItem>
                                <asp:ListItem Value="60" Text="60筆"></asp:ListItem>
                                <asp:ListItem Value="90" Text="90筆"></asp:ListItem>
                                <asp:ListItem Value="120" Text="120筆"></asp:ListItem>
                                <asp:ListItem Value="180" Text="180筆"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2">暗彩539</th>
                    </tr>
                     <tr>
                        <th class="td_title">啟用狀態：</th>
                        <td class="td_value">
                            <asp:CheckBox ID="chk_d539_status" runat="server" Text="啟用" /></td>
                    </tr>
                      <tr>
                        <th class="td_title">產生組數：</th>
                        <td class="td_value">

                            <asp:DropDownList ID="drp_d539_count" runat="server">
                                 <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6組"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7組"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8組"></asp:ListItem>
                                <asp:ListItem Value="9" Text="9組"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10組"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                        <th class="td_title">分析歷史來源筆數：</th>
                        <td class="td_value">
                            <asp:DropDownList ID="drp_d539_his_nums" runat="server">
                                
                                <asp:ListItem Value="30" Text="30筆"></asp:ListItem>
                                <asp:ListItem Value="60" Text="60筆"></asp:ListItem>
                                <asp:ListItem Value="90" Text="90筆"></asp:ListItem>
                                <asp:ListItem Value="120" Text="120筆"></asp:ListItem>
                                <asp:ListItem Value="180" Text="180筆"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="td_title">2星立柱產生組數：</th>
                        <td class="td_value">
                           立柱1：<asp:DropDownList ID="drp_dark539s2_1" runat="server">
                              
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                               
                              
                            </asp:DropDownList>
                            &nbsp;<Br />立柱2：<asp:DropDownList ID="drp_dark539s2_2" runat="server">
                               
                               <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                                
                             
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <th class="td_title">3星立柱產生組數：</th>
                        <td class="td_value">
                              立柱1：<asp:DropDownList ID="drp_dark539s3_1" runat="server">
                               
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                
                               
                               
                            </asp:DropDownList>
                            &nbsp;<Br />立柱2：<asp:DropDownList ID="drp_dark539s3_2" runat="server">
                                
                              <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                
                            
                            </asp:DropDownList>
                             &nbsp;<br />立柱3：<asp:DropDownList ID="drp_dark539s3_3" runat="server">
                                
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                               
                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <th class="td_title">4星立柱產生組數：</th>
                        <td class="td_value">
                              立柱1：<asp:DropDownList ID="drp_dark539s4_1" runat="server">
                              
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                              
                              
                            </asp:DropDownList>
                            &nbsp;<br />立柱2：<asp:DropDownList ID="drp_dark539s4_2" runat="server">
                               
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                              
                            </asp:DropDownList>
                            <br />
                              立柱3：<asp:DropDownList ID="drp_dark539s4_3" runat="server">
                               
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                              
                            </asp:DropDownList>
                             &nbsp;<br />立柱4：<asp:DropDownList ID="drp_dark539s4_4" runat="server">
                                
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                       <tr>
                       <th colspan="2">大樂透</th>
                    </tr>
                    <tr>
                        <th class="td_title">啟用狀態：</th>
                        <td class="td_value">
                            <asp:CheckBox ID="chk_l649_status" runat="server" Text="啟用" /></td>
                    </tr>
                      <tr>
                        <th class="td_title">產生組數：</th>
                        <td class="td_value">

                            <asp:DropDownList ID="drp_l649_count" runat="server">
                                <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6組"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7組"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8組"></asp:ListItem>
                                <asp:ListItem Value="9" Text="9組"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10組"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                        <th class="td_title">分析歷史來源筆數：</th>
                        <td class="td_value">
                            <asp:DropDownList ID="drp_l649_his_nums" runat="server">
                                
                                <asp:ListItem Value="30" Text="30筆"></asp:ListItem>
                                <asp:ListItem Value="60" Text="60筆"></asp:ListItem>
                                <asp:ListItem Value="90" Text="90筆"></asp:ListItem>
                                <asp:ListItem Value="120" Text="120筆"></asp:ListItem>
                                <asp:ListItem Value="180" Text="180筆"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                       <tr>
                       <th colspan="2">威力彩</th>
                    </tr>
                    <tr>
                        <th class="td_title">啟用狀態：</th>
                        <td class="td_value">
                            <asp:CheckBox ID="chk_sl_status" runat="server" Text="啟用" /></td>
                    </tr>
                     <tr>
                        <th class="td_title">產生組數：</th>
                        <td class="td_value">

                            <asp:DropDownList ID="drp_sl_count" runat="server">
                                 <asp:ListItem Value="1" Text="1組"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2組"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3組"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4組"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5組"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6組"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7組"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8組"></asp:ListItem>
                                <asp:ListItem Value="9" Text="9組"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10組"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                        <th class="td_title">分析歷史來源筆數：</th>
                        <td class="td_value">
                            <asp:DropDownList ID="drp_sl_his_nums" runat="server">
                                
                                <asp:ListItem Value="30" Text="30筆"></asp:ListItem>
                                <asp:ListItem Value="60" Text="60筆"></asp:ListItem>
                                <asp:ListItem Value="90" Text="90筆"></asp:ListItem>
                                <asp:ListItem Value="120" Text="120筆"></asp:ListItem>
                                <asp:ListItem Value="180" Text="180筆"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>

                        <th colspan="2">預測號碼相關設定</th>
                    </tr>
                    <tr>
                        <th class="td_title">預測產生號碼是否移除前期開出號碼：</th>
                        <td class="td_value">
                            <asp:RadioButtonList ID="rdo_removenumbers" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>

                        </td>
                    </tr>
                      <tr>
                        <th class="td_title">預測產生號碼是否啟用出現率範圍過濾：</th>
                        <td class="td_value">
                            <asp:RadioButtonList ID="rdo_fliterscope" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="1">是(採用平均法過濾)</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                                <asp:ListItem Value="2">是(自訂最大與最小範圍)</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Panel ID="pan_rm_scope" runat="server">範圍介於

                               最小值<asp:DropDownList ID="drp_scope_min" runat="server"></asp:DropDownList>~
                               最大值<asp:DropDownList ID="drp_scope_max" runat="server"></asp:DropDownList>

                            </asp:Panel>
                            
                        </td>
                    </tr>
                     <tr>
                        <th class="td_title">預測產生號碼要啟用的分析法：</th>
                        <td class="td_value">

                            <asp:CheckBoxList ID="chktype" runat="server" CellPadding="3" CellSpacing="3">
                               
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                      <tr>
                        <th class="td_title">歷史號碼加權機率：</th>
                        <td class="td_value">

                            <asp:RadioButtonList ID="rdo_is_weighted" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                   
                </table>
                    </div>
                <div style="margin-top:20px;">
                    <asp:Button ID="Button1" runat="server" Text="儲存"  OnClick="Button1_Click" />
                </div>
                
            </div>
        </div>

    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>

     

   

    </script>

</asp:Content>
