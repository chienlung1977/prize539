<%@ Page Title="開獎號碼" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prize539Next.aspx.cs" Inherits="com.oli365.prize.Member.Prize539Next" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        td {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div >
    <h3><b>本期預測號碼</b></h3>
</div>
    <div style="margin-top:10px;margin-bottom:10px">
        <input type="button" id="btnAdd" value="新增號碼"  />
        <div id="divAdd" style=";margin-top:10px;width:50%;margin-bottom:10px">
            <table border="1" width="100%">
                <tr>
                    <th>號碼1：</th>
                    <th>號碼2：</th>
                    <th>號碼3：</th>
                    <th>號碼4：</th>
                    <th>號碼5：</th>
                   
                </tr>
                  <tr>
                    
                       <td>
                        <asp:DropDownList ID="N1" runat="server"></asp:DropDownList>
                       
                    </td>
                       <td>
                        <asp:DropDownList ID="N2" runat="server"></asp:DropDownList>
                    </td>
                     <td>
                        <asp:DropDownList ID="N3" runat="server"></asp:DropDownList>
                    </td>
                       <td>
                        <asp:DropDownList ID="N4" runat="server"></asp:DropDownList>
                    </td>
                        <td>
                        <asp:DropDownList ID="N5" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="5">
                          <div >
                <asp:Button ID="btnAddSave" runat="server" Text="確定新增" OnClick="btnAddSave_Click" />
                <input type="button" id="btnCancel" value="取消" />
            </div>

                    </td>
                </tr>
               
            </table>
            
          
        </div>
    </div>
<div >
    <asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="NEXT_PRIZE_UID" AutoGenerateColumns="false" OnRowCommand="gv_RowCommand" OnRowCancelingEdit="gv_RowCancelingEdit" OnRowEditing="gv_RowEditing" OnRowUpdating="gv_RowUpdating" >
        <Columns>
            <asp:BoundField HeaderText ="分析方式" DataField="CAL_NAME" ReadOnly ="true" />
             <asp:BoundField HeaderText ="期數" DataField="NEXT_PERIOD" ReadOnly ="true" />
            <asp:BoundField HeaderText ="組數" DataField="LOTTO_NUM" ReadOnly ="true" />
            <asp:TemplateField HeaderText="號碼1">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"NUM1") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EN1" runat="server"></asp:DropDownList>
                    <input type="hidden" runat="server" id="hidN1" value='<%# DataBinder.Eval(Container.DataItem,"NUM1") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="號碼2">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"NUM2") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EN2" runat="server"></asp:DropDownList>
                    <input type="hidden" runat="server" id="hidN2" value='<%# DataBinder.Eval(Container.DataItem,"NUM2") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="號碼3">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"NUM3") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EN3" runat="server"></asp:DropDownList>
                    <input type="hidden" runat="server" id="hidN3" value='<%# DataBinder.Eval(Container.DataItem,"NUM3") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="號碼4">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"NUM4") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EN4" runat="server"></asp:DropDownList>
                    <input type="hidden" runat="server" id="hidN4" value='<%# DataBinder.Eval(Container.DataItem,"NUM4") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="號碼5">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"NUM5") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EN5" runat="server"></asp:DropDownList>
                    <input type="hidden" runat="server" id="hidN5" value='<%# DataBinder.Eval(Container.DataItem,"NUM5") %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="編輯">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="修改" CommandName="EDIT" />
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:Button ID="btnSave" runat="server" Text="儲存" CommandName="UPDATE" />
                     <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="CANCEL" />
                </EditItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="刪除">
                <ItemTemplate>
                    <asp:Button ID="btnDel" runat="server" Text="刪除" CommandName="DEL" OnClientClick="return confirm('確定要刪除？')" CommandArgument='<%# Container.DataItemIndex%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

    <div>
        <h3><b>上期開獎號碼及出現率分析</b></h3>
    </div>

    <div>
        <asp:GridView ID="nv" runat="server" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField HeaderText ="期數"  DataField="PERIOD" />
                <asp:BoundField HeaderText ="分析方式"  DataField="CAL_NAME" />
                <asp:BoundField HeaderText ="號碼1"  DataField="NUM1" />
                 <asp:BoundField HeaderText ="號碼1出現率"  DataField="NUM1P" DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼2"  DataField="NUM2" />
                <asp:BoundField HeaderText ="號碼2出現率"  DataField="NUM2P" DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼3"  DataField="NUM3" />
                <asp:BoundField HeaderText ="號碼3出現率"  DataField="NUM3P" DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼4"  DataField="NUM4" />
                <asp:BoundField HeaderText ="號碼4出現率"  DataField="NUM4P" DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼5"  DataField="NUM5" />
                <asp:BoundField HeaderText ="號碼5出現率"  DataField="NUM5P" DataFormatString="{0}%" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <h3><b>所有號碼出現率</b></h3>
    </div>
     <div>

         <asp:DataList ID="lv" runat="server" Width="100%" >
             <ItemTemplate>
                    <table width="100%" border="1">
                        <thead>
                            <tr>
                                <td colspan="10">分析方式：<%#Eval("CAL_NAME") %></td>
                            </tr>
                        </thead>
                        <tr style="background-color:#CCEEFF">
                            <td>01</td>
                            <td>02</td>
                            <td>03</td>
                            <td>04</td>
                            <td>05</td>
                            <td>06</td>
                            <td>07</td>
                            <td>08</td>
                            <td>09</td>
                            <td>10</td>
                        </tr>
                         <tr>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N01P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N02P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N03P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N04P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N05P","{0}%") %></td>
                             <td><%#DataBinder.Eval(Container.DataItem ,"N06P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N07P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N08P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N09P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N10P","{0}%") %></td>
                        </tr>

                         <tr style="background-color:#CCEEFF">
                            <td>11</td>
                            <td>12</td>
                            <td>13</td>
                            <td>14</td>
                            <td>15</td>
                            <td>16</td>
                            <td>17</td>
                            <td>18</td>
                            <td>19</td>
                            <td>20</td>
                        </tr>
                         <tr>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N11P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N12P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N13P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N14P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N15P","{0}%") %></td>
                             <td><%#DataBinder.Eval(Container.DataItem ,"N16P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N17P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N18P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N19P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N20P","{0}%") %></td>
                        </tr>

                         <tr style="background-color:#CCEEFF">
                            <td>21</td>
                            <td>22</td>
                            <td>23</td>
                            <td>24</td>
                            <td>25</td>
                            <td>26</td>
                            <td>27</td>
                            <td>28</td>
                            <td>29</td>
                            <td>30</td>
                        </tr>
                         <tr>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N21P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N22P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N23P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N24P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N25P","{0}%") %></td>
                             <td><%#DataBinder.Eval(Container.DataItem ,"N26P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N27P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N28P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N29P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N30P","{0}%") %></td>
                        </tr>
                         <tr style="background-color:#CCEEFF">
                            <td>31</td>
                            <td>32</td>
                            <td>33</td>
                            <td>34</td>
                            <td>35</td>
                            <td>36</td>
                            <td>37</td>
                            <td>38</td>
                            <td>39</td>
                            <td></td>
                        </tr>
                         <tr>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N31P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N32P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N33P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N34P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N35P","{0}%") %></td>
                             <td><%#DataBinder.Eval(Container.DataItem ,"N36P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N37P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N38P","{0}%") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem ,"N39P","{0}%") %></td>
                            <td></td>
                        </tr>
                    </table>
             </ItemTemplate>
         </asp:DataList>
     </div>

    <input type="hidden" id="hid_forecastUid" runat="server" />
    <input type="hidden" id="hid_forecastPeriod" runat="server" />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>
        $(function () {


            initData();


            $("#btnAdd").click(function () {
                $("#divAdd").show();
            });

            $("#btnCancel").click(function () {
                $("#divAdd").hide();
            });
        });


        function initData() {
            $("#divAdd").hide();
        }
    </script>

</asp:Content>
