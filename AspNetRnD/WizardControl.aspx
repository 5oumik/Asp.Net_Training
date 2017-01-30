<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WizardControl.aspx.cs" Inherits="AspNetRnD.WizardControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="Wizard1" runat="server" 
        onactivestepchanged="Wizard1_ActiveStepChanged" 
        oncancelbuttonclick="Wizard1_CancelButtonClick" 
        onnextbuttonclick="Wizard1_NextButtonClick" 
        onfinishbuttonclick="Wizard1_FinishButtonClick" 
        onpreviousbuttonclick="Wizard1_PreviousButtonClick" 
        onsidebarbuttonclick="Wizard1_SideBarButtonClick" ActiveStepIndex="1">
            <FinishNavigationTemplate>
                <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" />
                <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" Text="Finish" />
            </FinishNavigationTemplate>
        <SideBarStyle VerticalAlign="Top" />
            <StartNavigationTemplate>
                <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next" OnClientClick="return confirm('Are you sure you want to go to next step');" />
            </StartNavigationTemplate>
            <StepNavigationTemplate>
                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" />
                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" />
            </StepNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                    <asp:CheckBox ID="chkBoxCancel" Text="Cancel Navigation" runat="server" />
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2"></asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3"></asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
    </form>
</body>
</html>
