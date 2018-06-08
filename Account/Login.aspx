  <%@ Page  Title="會員登入" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"    CodeBehind="Login.aspx.cs" Inherits="com.oli365.prize.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
    
    <script>
  // This is called with the results from from FB.getLoginStatus().
  function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
      // Logged into your app and Facebook.
      testAPI();
    } else {
      // The person is not logged into your app or we are unable to tell.
   //   document.getElementById('status').innerHTML = 'Please log ' +
    //    'into this app.';
    }
  }

  // This function is called when someone finishes with the Login
  // Button.  See the onlogin handler attached to it in the sample
  // code below.
  function checkLoginState() {
    FB.getLoginStatus(function(response) {
      statusChangeCallback(response);
    });
  }

  window.fbAsyncInit = function() {
    FB.init({
        appId: '424638114716877',
      cookie     : true,  // enable cookies to allow the server to access 
                          // the session
      xfbml      : true,  // parse social plugins on this page
      version    : 'v2.8' // use graph api version 2.8
    });

    // Now that we've initialized the JavaScript SDK, we call 
    // FB.getLoginStatus().  This function gets the state of the
    // person visiting this page and can return one of three states to
    // the callback you provide.  They can be:
    //
    // 1. Logged into your app ('connected')
    // 2. Logged into Facebook, but not your app ('not_authorized')
    // 3. Not logged into Facebook and can't tell if they are logged into
    //    your app or not.
    //
    // These three cases are handled in the callback function.

    FB.getLoginStatus(function(response) {
      statusChangeCallback(response);
    });

  };

  // Load the SDK asynchronously
  (function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/zh_TW/all.js";
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

  // Here we run a very simple test of the Graph API after login is
  // successful.  See statusChangeCallback() for when this call is made.
  function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function(response) {
      console.log('Successful login for: ' + response.name);
//      document.getElementById('status').innerHTML =
  //      'Thanks for logging in, ' + response.name + '!';
    });
  }
</script>

<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = 'https://connect.facebook.net/zh_TW/sdk.js#xfbml=1&version=v3.0&appId=424638114716877&autoLogAppEvents=1';
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

   




   <div style="margin-top:20px;">
   <table style="margin-top:200px;" align=center border="1">
        <tr>
            <th>帳號：</th>
            <td><asp:TextBox runat="server" ID="txtAccount" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>密碼：</th>
            <td><asp:TextBox runat="server" ID="txtPwd" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Register_Member.aspx">註冊</asp:HyperLink>              
            &nbsp;<asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
   </table>

       <div style="text-align:center;margin-top:10px;">
             <asp:Button ID="btnSubmit" runat="server" Text="送出" OnClientClick="return check()" onclick="btnSubmit_Click" />

       </div>
       <div style="text-align:center;margin-top:10px;">
            <div class="fb-login-button" data-max-rows="1" data-size="medium" data-button-type="continue_with" data-show-faces="false" data-auto-logout-link="false" data-use-continue-as="true"></div>

       </div>

     

   </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>

        function check() {

            if ($("#ctl00_MainContent_txtAccount").val() == "") {
                alert('請輸入登入帳號');
                $("#ctl00_MainContent_txtAccount").focus();
                return false;
            }

            if ($("#ctl00_MainContent_txtPwd").val() == "") {
                alert('請輸入登入密碼');
                $("#ctl00_MainContent_txtPwd").focus();
                return false;
            }

            return true;

        }

    </script>

    </asp:Content>