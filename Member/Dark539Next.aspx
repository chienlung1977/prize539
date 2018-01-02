<%@ Page Title="開獎號碼" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dark539Next.aspx.cs" Inherits="com.oli365.prize.Member.Dark539Next" %>
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

<div >
    <asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="NEXT_PRIZE_UID" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText ="分析方式" DataField="CAL_NAME" ReadOnly ="true" />
             <asp:BoundField HeaderText ="期數" DataField="NEXT_PERIOD" ReadOnly ="true" />
             <asp:BoundField HeaderText="筆數" DataField="SORT_NUM" ReadOnly ="true" />
            <asp:BoundField HeaderText ="2星立柱1" DataField="2_STAR_1" ReadOnly ="true" />
            <asp:BoundField HeaderText ="2星立柱2" DataField="2_STAR_2"  />
            <asp:BoundField HeaderText ="3星立柱1" DataField="3_STAR_1"  />
            <asp:BoundField HeaderText ="3星立柱2" DataField="3_STAR_2"  />
            <asp:BoundField HeaderText ="3星立柱3" DataField="3_STAR_3"  />
            <asp:BoundField HeaderText ="4星立柱1" DataField="4_STAR_1"  />
            <asp:BoundField HeaderText ="4星立柱2" DataField="4_STAR_2"  />
            <asp:BoundField HeaderText ="4星立柱3" DataField="4_STAR_3"  />
            <asp:BoundField HeaderText ="4星立柱4" DataField="4_STAR_4"  />
            <asp:TemplateField Visible="false">
            <HeaderTemplate>
                <asp:LinkButton ID="lbInsert" runat="server">新增</asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="lbEdit" runat="server" 
                CommandName="Edit">編輯</asp:LinkButton> 
                |
                <asp:LinkButton ID="lbDelete" runat="server" 
                OnClientClick="javascript:return confirm('確定刪除?')" 
                CommandName="Delete">刪除</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lbUpdate" runat="server" 
                CommandName="Update">更新</asp:LinkButton>
                |
                <asp:LinkButton ID="lbCancelUpdate" runat="server" 
                CommandName="Cancel">取消</asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lbSave" runat="server" 
               >儲存</asp:LinkButton>
                |
                <asp:LinkButton ID="lbCancelSave" runat="server" 
               >取消</asp:LinkButton>
            
            </FooterTemplate>
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
 
     <div style="margin-top:20px">

         <asp:DataList ID="lv" runat="server" Width="100%" >
             
             <ItemTemplate>
                    <table width="100%" border="1">
                        <thead>
                          
                          
                            <tr>
                                <td colspan="10"> <b>第<%#Eval("PERIOD") %>期所有號碼出現率，分析方式：<%#Eval("CAL_NAME") %></b></td>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
