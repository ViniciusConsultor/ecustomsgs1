using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ApplicationUtils.Constants
{
	public class TranslationsConstants
	{
		#region Goal Definition based controls

		public static string GoalAchieved_To = "to";
		public static string GoalAchieved_Client = "Anteil Klient";
		public static string GoalAchieved_HelpText = "None";
		public static string GoalAchieved_Comments = "Comments";
		public static string GoalAchieved_Through = "Through";

		public static string GoalDefinitionComboHelp = "GoalDefinitionComboHelp";
		public static string GoalReached = "GoalReached";
		public static string GoalNotCurrent = "GoalNotCurrent";
		public static string GoalFuture = "GoalFuture";
		public static string GoalSubgoals = "Subgoals";
		public static string GoalHelpText = "GoalHelpText";
		public static string GoalRelatedItems_HelpText = "GoalRelatedItems_HelpText";
		public static string GoalDefinition_ProArgs = "GoalDefinition_ProArgs";
		public static string GoalDefinition_ContraArgs = "GoalDefinition_ContraArgs";

		public static string GoalDefinition_ResourcesBarriers = "GoalDefinition_ResourcesBarriers";
		public static string GoalDefinition_PersonalResources = "GoalDefinition_PersonalResources";
		public static string GoalDefinition_EnveronmentalResources = "GoalDefinition_EnveronmentalResources";
		public static string GoalDefinition_PersonalBarriers = "GoalDefinition_PersonalBarriers";
		public static string GoalDefinition_EnveronmentalBarriers = "GoalDefinition_EnveronmentalBarriers";
		public static string GoalAchieved_Finished = "GoalAchieved_Finished";

		#endregion

		#region LabelPlus based controls

		#endregion

		#region --- SimpleTextBox ---

		public static int STEXTBOX_OFFSET = 2;
		public static Font STEXTBOX_DEFAULT_FONT = GDIConstants.UIStandardFont;
		public static int STEXTBOX_WARNINGBOX_SIZE = 16;
		public static int STEXTBOX_DEFAULT_MIN_WIDTH = 20;
		public static int STEXTBOX_DEFAULT_WIDTH = 100;

		public static string STEXTBOX_INVALID_TEXT = "SimpleTextBox_InvalidText";
		public static string STEXTBOX_INVALID_NUMBER = "SimpleTextBox_InvalidNumber";
		public static string STEXTBOX_INVALID_DATE = "SimpleTextBox_InvalidDate";

		public static int STEXTBOX_HEIGHT = 20;

		#endregion --- SimpleTextBox ---

		#region --- MultiTextBox ---

		public static int MTEXTBOX_PLUSBUTTON_WIDTH = STEXTBOX_HEIGHT;
		public static int MTEXTBOX_DEFAULT_WIDTH = STEXTBOX_DEFAULT_WIDTH + MTEXTBOX_PLUSBUTTON_WIDTH;
		public static int MTEXTBOX_VERTICAL_GAP = 4;

		#endregion --- MultiTextBox ---

		#region --- AddressBox ---

		public static int ABOX_VERTICAL_GAP = 4;
		public static int ABOX_HEIGHT = 4 * STEXTBOX_HEIGHT + 2 * ABOX_VERTICAL_GAP;
		public static int ABOX_DEFAULT_WIDTH = STEXTBOX_DEFAULT_WIDTH;

		#endregion --- AddressBox ---

		#region --- CalendarPlus ---

		public static string CALENDAR_TODAY = "CalendarPlus_Today";
		public static string CALENDAR_DATE_TITLE = "CalendarPlus_Title";
		public static string CALENDAR_BUTTON_SELECT_DATE = "CalendarPlus_btnSelectData";

		#endregion --- CalendarPlus ---

		#region --- DatedEntry ---

		public static string DATED_ENTRY_SINCE = "DatedEntry_since";
		public static string DATED_ENTRY_FROM = "DatedEntry_from";
		public static string DATED_ENTRY_UNTIL = "DatedEntry_until";

		#endregion

		#region - - Journal - -

		public static string JournalItem_TimeSpent = "Work Time Spent";
		public static string JournalItem_Attachments = "Attachments";
		public static string JournalItem_HelpText = "JournalItem_HelpText";
		public static string JournalItem_About = "JournalItem_About";
		public static string JournalItem_About_Empty = "JournalItem_About_Empty";
		public static string JournalItem_Authors = "JournalItem_Authors";
		public static string JournalItem_Themes = "JournalItem_Themes";
		public static string JournalItem_Domains = "JournalItem_Domains";
		public static string JournalItem_EntryTypes = "JournalItem_EntryTypes";
		public static string JournalItem_ImportantDevelopment = "JournalItem_ImportantDevelopment";
		public static string JournalItem_UploadButtonCaption = "JournalItem_UploadButtonCaption";

		public static string JournalFilter_FullTextLabel = "JournalFilter_FullTextLabel";
		public static string JournalFilter_FullTextHelp = "JournalFilter_FullTextHelp";

		public static string DatedEntry_from = "DatedEntry_from";
		public static string DatedEntry_On = "DatedEntry_On";
		public static string DatedEntry_Hour = "DatedEntry_Hour";
		public static string JournalAttachmentNotFound = "JournalAttachmentNotFound";
		public static string JournalItem_ConcerningDate = "JournalItem_ConcerningDate";

		#endregion

		#region YesNoDialog

		public static string LabelYes = "Label Yes";
		public static string LabelNo = "Label No";
		public static string LabelOk = "LabelOk";
		public static string LabelCancel = "LabelCancel";

		#endregion

		#region TextSearch

		public static string TextSearchHelpText = "TextSearchHelpText";

		#endregion

		#region EvaluationDomainControl

		public static string EvaluationDomainControl_CheckBoxText = "EvaluationDomainControl_CheckBoxText";
		public static string EvaluationDomainControl_CheckBoxText_Long = "EvaluationDomainControl_CheckBoxText_Long";

		#endregion

		#region EvaluationCommentsListControl

		public static string CommentsListCaption = "CommentsListCaption";

		#endregion

		#region EvaluationThemesListControl

		public static string ThemeList_AddNew = "ThemeList_AddNew";

		#endregion

		public static string BiographyEventNew = "New Event";
		public static string BiographyEventDescription = "Description";

		public static string MONTH = "Month";
		public static string YEAR = "Year";
		public static string WEEK = "Week";
		public static string DAY = "Day";

		public static string EvaluationCommentHelpText = "EvaluationCommentHelpText";

		#region DropDownPlus

		public static string DropDownPlus_ItemNotFound = "DropDownPlus_ItemNotFound";

		#endregion

		#region StartDateEndDateControl

		public static string StartDateEndDateControl_StartDateLabel = "StartDateEndDateControl_StartDateLabel";
		public static string StartDateEndDateControl_StartDateHelpText = "StartDateEndDateControl_StartDateHelpText";
		public static string StartDateEndDateControl_EndDateLabel = "StartDateEndDateControl_EndDateLabel";
		public static string StartDateEndDateControl_EndDateHelpText = "StartDateEndDateControl_EndDateHelpText";

		#endregion

		#region Save Diagram Template

		public static string GroupDiagramTemplateAlreadyExisting = "GroupDiagramTemplateAlreadyExisting";
		public static string OrganisationDiagramTemplateAlreadyExisting = "OrganisationDiagramTemplateAlreadyExisting";
		public static string RelationshipDiagramLastModifiedBy = "Last edited by";
		public static string RelationshipDiagramGenogramDropDownHelpText = "RelationshipDiagramGenogramDropDownHelpText";
		public static string RelationshipDiagramDisplayGenogram = "RelationshipDiagramDisplayGenogram";

		public static string RelationshipDiagram_FilterPrimary = "RelationshipDiagram_FilterPrimary";
		public static string RelationshipDiagram_FilterSecondary = "RelationshipDiagram_FilterSecondary";
		public static string RelationshipDiagram_FilterAll = "RelationshipDiagram_FilterAll";


		#endregion

		#region ClassificationEvaluationControl

		public static string ClassificationEvaluation_LinkLabelText = "ClassificationEvaluation_LinkLabelText";
		public static string ClassificationEvaluation_PersonsLabelText = "ClassificationEvaluation_PersonsLabelText";
		public static string ClassificationEvaluation_PersonsHelpText = "ClassificationEvaluation_PersonsHelpText";

		public static string ClassificationEvaluation_ButtonShowHideDescriptionCaption =
			"ClassificationEvaluation_ButtonShowHideDescriptionCaption";

		public static string ClassificationEvaluation_ButtonSearchCaption = "ClassificationEvaluation_ButtonSearchCaption";
		public static string ClassificationEvaluation_ButtonAktuelleCaption = "ClassificationEvaluation_ButtonAktuelleCaption";
		public static string ClassificationEvaluation_MoreButtonCaption = "ClassificationEvaluation_MoreButtonCaption";
		public static string ClassificationEvaluation_TitleFooter = "ClassificationEvaluation_TitleFooter";

		#endregion

		#region AchievedThrough

		public static string AchievedThrough_HelpCostUnit = "AchievedThrough_HelpCostUnit";
		public static string AchievedThrough_HelpCostPeriodicity = "AchievedThrough_HelpCostPeriodicity";

		public static string AchievedThrough_HelpTimeUnit = "AchievedThrough_HelpTimeUnit";
		public static string AchievedThrough_HelpTimePeriodicity = "AchievedThrough_HelpTimePeriodicity";

		#endregion

		#region CalendarAppoitment

		public static string SchedulerStringId_CloseCalendar = "SchedulerStringId.CloseCalendar";
		public static string SchedulerStringId_NewAppointmentAllVisible = "SchedulerStringId.NewAppointmentAllVisible";
		public static string SchedulerStringId_NewAppointmentWizzard = "SchedulerStringId.NewAppointmentWizzard";
		public static string SchedulerStringId_EditAppointment = "SchedulerStringId.EditAppointment";
		public static string SchedulerStringId_DeleteAppointment = "SchedulerStringId.DeleteAppointment";

		public static string SchedulerCustomAppointmentFormCaption = "SchedulerCustomAppointmentFormCaption";
		public static string SchedulerCustomAppointmentFormCheckAll = "SchedulerCustomAppointmentFormCheckAll";
		public static string SchedulerCustomAppointmentFormUncheckAll = "SchedulerCustomAppointmentFormUncheckAll";
		public static string CalendarAppointmentForm_CannotSelectAppointmentType = "CalendarAppointmentForm_CannotSelectAppointmentType";
		public static string CalendarAppointment_ShowOwnCalendar = "CalendarAppointment_ShowOwnCalendar";
		public static string CalendarAppointment_HideOwnCalendar = "CalendarAppointment_HideOwnCalendar";
		public static string CalendarAppointment_IlegitimAbsence_True = "CalendarAppointment_IlegitimAbsence_True";
		public static string CalendarAppointment_IlegitimAbsence_False = "CalendarAppointment_IlegitimAbsence_False";
		public static string CalendarAppointment_AllDay_True = "CalendarAppointment_AllDay_True";
		public static string CalendarAppointment_AllDay_False = "CalendarAppointment_AllDay_False";
		#endregion

		public static string MedicationLabelDiscontinuedByPerson = "MedicationLabelDiscontinuedByPerson";
		public static string MedicationTextBoxDiscontinuedByPerson = "MedicationTextBoxDiscontinuedByPerson";
		public static string MedicationLabelDiscontinuedOn = "MedicationLabelDiscontinuedOn";
		public static string MedicationLabelDosageEvening = "MedicationLabelDosageEvening";
		public static string MedicationLabelDosageMorning = "MedicationLabelDosageMorning";
		public static string MedicationLabelDosageNight = "MedicationLabelDosageNight";
		public static string MedicationLabelRemarks = "MedicationLabelRemarks";
		public static string MedicationLabelCreatedBy = "MedicationLabelCreatedBy";
		public static string MedicationLabelOrganizer = "MedicationLabelOrganizer";
		public static string MedicationLabelDosageNoon = "MedicationLabelDosageNoon";
		public static string MedicationLabelFrequency = "MedicationLabelFrequency";
		public static string MedicationLabelIndications = "MedicationLabelIndications";
		public static string MedicationLabelMedicament = "MedicationLabelMedicament";
		public static string MedicationLabelMedicationType = "MedicationLabelMedicationType";
		public static string MedicationLabelMedicatedOn = "MedicationLabelMedicatedOn";
		public static string MedicationLabelPharmaceuticalForm = "MedicationLabelPharmaceuticalForm";
		public static string MedicationLabelMedicatedByPerson = "MedicationLabelMedicatedByPerson";
		public static string MedicationLabelDosageMax = "MedicationLabelDosageMax";
		public static string MedicationLabelAlergy = "MedicationLabelAlergy";
		public static string MedicationProviderLabel = "MedicationProviderLabel";

		public static string MedicationMedicatedOnHelpText = "MedicationMedicatedOnHelpText";
		public static string MedicationDateDiscontinuedOnHelpText = "MedicationDateDiscontinuedOnHelpText";
		public static string MedicationMedicamentHelpText = "MedicationMedicamentHelpText";
		public static string MedicationDosageMorningHelpText = "MedicationDosageMorningHelpText";
		public static string MedicationDosageNoonHelpText = "MedicationDosageNoonHelpText";
		public static string MedicationDosageEveningHelpText = "MedicationDosageEveningHelpText";
		public static string MedicationFrequencyHelpText = "MedicationFrequencyHelpText";
		public static string MedicationDosageNightHelpText = "MedicationDosageNightHelpText";
		public static string MedicationIndicationsHelpText = "MedicationIndicationsHelpText";
		public static string MedicationRemarksHelpText = "MedicationRemarksHelpText";
		public static string MedicationPharmaceuticalFormHelpText = "MedicationPharmaceuticalFormHelpText";
		public static string MedicationDosageMaxHelpText = "MedicationDosageMaxHelpText";
		public static string MedicationAlergyHelpText = "MedicationAlergyHelpText";
		public static string MedicationProviderHelpText = "MedicationProviderHelpText";
		public static string MedicationDownMedicationTypeHelpText = "MedicationDownMedicationTypeHelpText";
		public static string MedicationDownMedicatedByHelpText = "MedicationDownMedicatedByHelpText";
		public static string MedicationDownDiscontinuedByHelpText = "MedicationDownDiscontinuedByHelpText";

		public static string MedicationFilterMedicationType = "MedicationFilterMedicationType";
		public static string MedicationFilterMedicationOn = "MedicationFilterMedicationOn";

		public static string MedicationFilterSorting = "MedicationFilterSorting";
		public static string MedicationFilterFilter = "MedicationFilterFilter";
		public static string MedicationFilterDate = "MedicationFilterDate";
		public static string MedicationFilterDateHelpText = "MedicationFilterDateHelpText";
		public static string MedicationFilterDateLabel = "MedicationFilterDateLabel";

		public static string Medication_DeleteEntry = "Medication_DeleteEntry";

		#region ++ dialogs ++

		public static string CannotLeaveRow = "CannotLeaveRow";

		#endregion

		#region --General--

		public static string AppTimeOutMes = "AppTimeOutMes";

		public static string Global_Last = "last";
		public static string Global_All = "all";
		public static string Global_Entries = "entries";
		public static string Global_OutOf = "out of";

		public static string Global_Yes = "Yes";
		public static string Global_No = "No";

		#endregion

		#region  --- Menus ---

		public static string MenuFile = "&File";
		public static string MenuPrint = "&Print";
		public static string MenuExportExcel = "Export to Excel";
		public static string MenuEdit = "&Edit";
		public static string MenuView = "&View";
		public static string MenuExtra = "E&xtra";
		public static string MenuHelp = "&Help";
		public static string MenuLanguage = "&Language";
		public static string MenuUndo = "&Undo";
		public static string MenuRedo = "&Redo";
		public static string MenuFile_ChangePassword = "MenuFile_ChangePassword";
		public static string MenuPersonInformationApplication = "Person Information";
		public static string MenuJournalApplication = "Journal";
		public static string MenuProcessOrganizationApplication = "Process Organization";
		public static string MenuHtmlReportApplication = "Reports";
		public static string MenuOfficeApplication = "Office";
		public static string MenuResetOfficeData = "Reset Office Data";
		public static string MenuEnableSpellChecker = "Enable Spell Checker";
		public static string MenuDisableSpellChecker = "Disable Spell Checker";

		public static string MenuLabelGroup = "Group";
		public static string MenuLabelLoggedUser = "Logged as";
		public static string MenuUserNotSelected = "MenuUserNotSelected";
		public static string MenuAbout = "MenuAbout";
		public static string MenuContents = "MenuContents";
		public static string MenuExit = "MenuExit";

		public static string Edit_Copy = "Copy";
		public static string Edit_Cut = "Cut";
		public static string Edit_Paste = "Paste";
		public static string Edit_Delete = "Delete";

		#endregion

		#region Process Management

		public static string ActivityInfo_FirstUsed = "First Used";
		public static string ActivityInfo_LastUsed = "Last Used";
		public static string ActivityInfo_Ignored = "Ignored";
		public static string ActivityInfo_Finished = "Finished";
		public static string ActivityInfo_Date = "Date";
		public static string ActivityInfo_NotYet = "not yet";
		public static string ActivityInfo_CantUse = "This tool can't be used yet.";

		public static string PhaseInfo_Start = "Start";
		public static string PhaseInfo_End = "End";
		public static string PhaseInfo_Open = "Open";

		public static string Process_CurrentPhase = "Current Phase";
		public static string Process_Today = "Today";
		public static string Process_Title = "ProcessManagementTitle";
		public static string Process_New = "New";
		public static string Process_Delete = "Delete";
		public static string Process_DeleteNo = "DeleteProcessNo";
		public static string Process_Close = "Close Process";
		public static string Process_Reset = "Reset";
		public static string ShortProcessInfo_NotFoundCurrentProcess = "ShortProcessInfo_NotFoundCurrentProcess";

		#endregion

		#region Person Information

		public static string PersonInformation = "Person Information";
		public static string PersonInformationComboGroup = "Group";
		public static string PersonInformationComboCategory = "Category";
		public static string Person_Category = "Category";
		public static string Person_All = "All";
		public static string Person_Categories = "Categories";
		public static string Person_AddNewItem = "Add New Item ...";
		public static string Person_Caption = "Person";
		public static string Person_Persons = "Persons";
		public static string Person_AddNewPerson = "Add New Person ...";
		public static string Person_NewPerson = "New Person";
		public static string PersonInformation_Advanced = "PersonInformation_Advanced";
		public static string PersonInformation_MyClients = "PersonInformation_MyClients";
		public static string PersonInformation_ShowOnlyClients = "PersonInformation_ShowOnlyClients";
		public static string PersonInformation_ShowOnlyPersonsFromCurrentGroup = "PersonInformation_ShowOnlyPersonsFromCurrentGroup";
		public static string PersonInformation_All = "PersonInformation_All";
		public static string PersonInformation_Close = "Close";

		public static string PersonInformation_NotAllowToChangeToUser = "PersonInformation_NotAllowToChangeToUser";
		public static string PersonInformation_NotAllowedToDelete = "PersonInformation_NotAllowedToDelete";
		public static string PersonInformation_DeletedPersons = "Deleted Persons";
		public static string PersonInformation_DeletedConfirmation = "PersonInformation_DeletedConfirmation";
		public static string PersonInformation_AddNewProcess = "PersonInformation_AddNewProcess";
		public static string PersonInformation_CannotDeleteUser = "PersonInformation_CannotDeleteUser";
		public static string PersonInformation_CannotDeleteCurrentUser = "PersonInformation_CannotDeleteCurrentUser";
		public static string PersonInformation_NameCannotBeEmpty = "PersonInformation_NameCannotBeEmpty";

		public static string PersonInformation_DuplicatePersonButtonCaption = "PersonInformation_DuplicatePersonButtonCaption";
		public static string PersonInformation_ACategoryMustBeSelected = "PersonInformation_ACategoryMustBeSelected";
		public static string PersonInformation_ReactivatePersonConfirmation = "PersonInformation_ReactivatePersonConfirmation";

		#endregion

		#region Relationship Diagram

		public static string RelationshipDiagram_DeleteConfirmation = "RelationshipDiagram_DeleteConfirmation";
		public static string RelationshipDiagram_PersonShortInfoCaption = "RelationshipDiagram_PersonShortInfoCaption";
		public static string RelationshipDiagram_PersonRelationshipInfo = "RelationshipDiagram_PersonRelationshipInfo";
		public static string RelationshipDiagram_PersonRelationshipInfoButtonAddNew = "RelationshipDiagram_PersonRelationshipInfoButtonAddNew";
		public static string RelationshipDiagram_PersonSelectionDialogExistPersonLabel = "RelationshipDiagram_PersonSelectionDialogExistPersonLabel";
		public static string RelationshipDiagram_PersonSelectionDialogDisplay = "RelationshipDiagram_PersonSelectionDialogDisplay";
		public static string RelationshipDiagram_RoleQuality = "RelationshipDiagram_RoleQuality";
		public static string RelationshipDiagram_RolePositivity = "RelationshipDiagram_RolePositivity";
		public static string RelationshipDiagram_CopyCustom = "RelationshipDiagram_CopyCustom";

		#endregion

		#region Journal

		public static string Journal_TimeSpentCaption = "Work Time Spent";
		public static string Journal_AttachmentsCaption = "Attachments";
		public static string JournalEntryDataDeleteConfirmation = "JournalEntryData Delete Confirmation";
		public static string Journal_DomainsCaption = "Journal_DomainsCaption";
		public static string Journal_ThemesCaption = "Journal_ThemesCaption";
		public static string Journal_PersonsCaption = "Journal_PersonsCaption";
		public static string Journal_DefaultColor = "black";
		public static string Journal_RedColor = "red";
		public static string Journal_GreenColor = "green";
		public static string Journal_Filter_With = "Journal_Filter_With";
		public static string Journal_Filter_Without = "Journal_Filter_Without";
		public static string Journal_Filter_All = "Journal_Filter_All";
		public static string Journal_Filter_Yes = "Journal_Filter_Yes";
		public static string Journal_Filter_No = "Journal_Filter_No";

		public static string ChangeHomeGroup_HelpText = "ChangeHomeGroup_HelpText";
		public static string ChangeHomeGroup_ButtonChangeCaption = "ChangeHomeGroup_ButtonChangeCaption";

		#endregion

		#region Theme list

		public static string ThemeDeleteConfirmation = "ThemeDeleteConfirmation";

		#endregion

		#region Client Control

		public static string ClientControl_ClientSelection = "ClientControl_ClientSelection";
		public static string ClientControl_PersonSelection = "ClientControl_PersonSelection";
		public static string ClientControl_MyClients = "ClientControl_MyClients";
		public static string ClientControl_MyClientsHelpText = "ClientControl_MyClientsHelpText";

		#endregion

		#region Person Description

		public static string PersonDescription_PointsOfTheDescription = "PersonDescription_PointsOfTheDescription";
		public static string PersonDescription_Evaluation = "PersonDescription_Evaluation";
		public static string PersonDescription_EvaluationsAndThemes = "PersonDescription_EvaluationsAndThemes";
		public static string PersonDescription_DeleteConfirmation = "PersonDescription_DeleteConfirmation";
		public static string PersonDescription_CommentsAndThemes = "PersonDescription_CommentsAndThemes";
		public static string PersonDescription_CommentsList = "PersonDescription_CommentsList";
		public static string PersonDescription_ThemesList = "PersonDescription_ThemesList";
		public static string PersonDescription_A = "PersonDescriptionA";
		public static string PersonDescription_B = "PersonDescriptionB";
		public static string PersonDescription_C = "PersonDescriptionC";
		public static string PersonDescription_BodyTitle = "Person Description";

		#endregion

		#region Format And Search Toolbar

		public static string FormatAndSearchToolbar_Bold = "FormatAndSearchToolbar_Bold";
		public static string FormatAndSearchToolbar_Italic = "FormatAndSearchToolbar_Italic";
		public static string FormatAndSearchToolbar_Bullets = "FormatAndSearchToolbar_Bullets";
		public static string FormatAndSearchToolbar_Title = "FormatAndSearchToolbar_Title";
		public static string FormatAndSearchToolbar_Critical = "Critical Events";
		public static string FormatAndSearchToolbar_Print = "Print";

		#endregion

		#region WorkInfoControl

		public static string WorkInfoControl_Finished = "WorkInfoControl_Finished";
		public static string WorkInfoControl_Date = "WorkInfoControl_Date";

		#endregion

		#region TaskBarControl

		public static string TaskBarControl_FullScreen = "TaskBarControl_FullScreen";

		#endregion

		#region GenericHelpControl

		public static string GenericHelpControlFirstColumn = "GenericHelpControlFirstColumn"; //Descriptions and Tools
		public static string GenericHelpControlSecondColumn = "GenericHelpControlSecondColumn"; //Descriptions and Tools

		#endregion

		#region Diagnose

		public static string Diagnose_Diagnose = "Diagnose_Diagnose";
		public static string Diagnose_for = "Diagnose_for";
		public static string Diagnose_group = "Diagnose_group";
		public static string Diagnose_writtenby = "Diagnose_writtenby";

		#endregion

		#region GoalDefinition

		public static string GoalDefinition_HeaderGoalDefinition = "GoalDefinition_HeaderGoalDefinition";
		public static string GoalDefinition_HeaderEffects = "GoalDefinition_HeaderEffects";
		public static string ICFGoalDefinition_HeaderPersons = "ICFGoalDefinition_HeaderPersons";
		public static string GoalDefinition = "Goal Definition";
		public static string GoalDefinition_HeaderAchievedThrough = "GoalDefinition_HeaderAchievedThrough";
		public static string GoalDefinition_HeaderActionSteps = "GoalDefinition_HeaderActionSteps";
		public static string GoalDefinition_HeaderBestWorse = "GoalDefinition_HeaderBestWorse";
		public static string GoalDefinition_HeaderMentalModel = "GoalDefinition_HeaderMentalModel";
		public static string GoalDefinition_HeaderByWhom = "GoalDefinition_HeaderByWhom";
		public static string GoalDefinition_HeaderReached = "GoalDefinition_HeaderReached";
		public static string GoalDefinition_HeaderRestrictions = "GoalDefinition_HeaderRestrictions";

		public static string SelectActionPlan = "Select Action Plan";
		public static string EvaluationGoals = "Evaluation Goals";
		public static string EvaluateGoals = "Evaluate Goals";
		public static string EvaluationGoals_HeaderComment = "EvaluationGoals_HeaderComment";

		public static string GoalDefinition_CannotAddSubgoal = "GoalDefinition_CannotAddSubgoal";
		public static string GoalDefinition_ShouldAttach = "GoalDefinition_ShouldAttach";

		public static string Reflection_ApplicationTitle = "Reflection of Action Plans";

		#endregion

		#region UserPasswordDialog

		public static string UserPasswordDialog_Password = "UserPasswordDialog_Password";
		public static string UserPasswordDialog_OldPassword = "UserPasswordDialog_OldPassword";
		public static string UserPasswordDialog_ConfirmationPassword = "UserPasswordDialog_ConfirmationPassword";

		#endregion

		#region AddSphereDialog

		public static string AddSphereDialog_Caption = "AddSphereDialog_Caption";
		public static string AddSphereDialog_Scope = "AddSphereDialog_Scope";
		public static string AddSphereDialog_ProductGroup = "AddSphereDialog_ProductGroup";

		public static string AddSphereDialog_CaptionExists_Error = "AddSphereDialog_CaptionExists_Error";
		public static string AddSphereDialog_Scope_NoScopeSelected = "AddSphereDialog_Scope_NoScopeSelected";
		public static string AddSphereDialog_CaptionVoid_Error = "AddSphereDialog_CaptionVoid_Error";

		#endregion

		#region SphereInfoControl

		public static string SphereInfoControl_labelCaption_Text = "SphereInfoControl_labelCaption_Text";
		public static string SphereInfoControl_labelScope_Text = "SphereInfoControl_labelScope_Text";
		public static string SphereInfoControl_labelTimeClassification_Text = "SphereInfoControl_labelTimeClassification_Text";
		public static string SphereInfoControl_labelExposure_Text = "SphereInfoControl_labelExposure_Text";
		public static string SphereInfoControl_labelPositivity_Text = "SphereInfoControl_labelPositivity_Text";
		public static string SphereInfoControl_labelProductGroup_Text = "SphereInfoControl_labelProductGroup_Text";
		public static string SphereInfoControl_ControlCaption_Text = "SphereInfoControl_ControlCaption_Text";

		#endregion

		#region SphereOfLifeSelectionPanel

		public static string SphereOfLifeSelectionPanel_Cannot_Remove_Sphere = "SphereOfLifeSelectionPanel_Cannot_Remove_Sphere";
		public static string SphereOfLifeSelectionPanel_List_Caption = "SphereOfLifeSelectionPanel_List_Caption";
		public static string SphereOfLifeSelectionPanel_List_Header = "SphereOfLifeSelectionPanel_List_Header";

		#endregion

		#region JournalFilterProvider

		public static string JournalFilterProvider_Caption = "JournalFilterProvider_Caption";
		public static string JournalFilterProvider_PersonsListHelpText = "JournalFilterProvider_PersonsListHelpText";
		public static string JournalFilterProvider_PersonsListLabel = "JournalFilterProvider_PersonsListLabel";
		public static string JournalFilterProvider_Apply = "JournalFilterProvider_Apply";
		public static string JournalFilterProvider_Reset = "JournalFilterProvider_Reset";
		public static string JournalFilterProvider_EntryTypesLabel = "JournalFilterProvider_EntryTypesLabel";

		#endregion

		#region Evaluation Time Spent

		public static string EvTimeSpentAppTitle = "Evaluation Time Spent";
		public static string EvTimeSpentHead_EntryType = "Entry type";
		public static string EvTimeSpentHead_DuringProcess = "Time spent on this process";
		public static string EvTimeSpentHead_Overall = "Total time spent";
		public static string EvTimeSpentTotal = "Total";

		#endregion

		#region Implementation

		public static string ImplementationAppCaption = "Implementation";

		#endregion

		#region Diagnose Evaluation

		public static string DiagnoseEvaluation_HeaderTheme = "DiagnoseEvaluation_HeaderTheme";
		public static string DiagnoseEvaluation_HeaderEvaluation = "DiagnoseEvaluation_HeaderEvaluation";
		public static string DiagnoseEvaluation_HeaderPersons = "DiagnoseEvaluation_HeaderPersons";
		public static string DiagnoseEvaluation_DeleteConfirmation = "DiagnoseEvaluation_DeleteConfirmation";

		#endregion

		#region RTF string constants

		public static string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";

		/* RTF DOCUMENT AREA
		 * -----------------
		 * 
		 * \viewkind[N]	- The type of view or zoom level.  \viewkind4 specifies normal view.
		 * \uc[N]		- The number of bytes corresponding to a Unicode character.
		 * \pard		- Resets to default paragraph properties
		 * \cf[N]		- Foreground color.  \cf1 refers to the color at index 1 in
		 *				  the color table
		 * \f[N]		- Font number. \f0 refers to the font at index 0 in the font
		 *				  table.
		 * \fs[N]		- Font size in half-points.
		 * */
		public static string RTF_DOCUMENT_DEF = @"\viewkind4\uc1\cf1\f0\fs16 ";
		public static string RTF_DOCUMENT_BIG = @"\viewkind4\uc1\cf1\f0\fs24 ";
		public static string RTF_DOCUMENT_POST = @" \cf0}";

		#endregion

		public const string LogIn_WrongPassword = "LogIn_WrongPassword";
		public const string LogIn_BlockedOnServerForTheMoment = "LogIn_BlockedOnServerForTheMoment";
		public const string LogIn_UserNotMemberOfGroup = "LogIn_UserNotMemberOfGroup";
		public const string LogIn_WrongConfirmationPassword = "LogIn_WrongConfirmationPassword";

		public static string Export2Word_WaitMessage = "Export2Word_WaitMessage";

		#region SOL

		public static string SphereOfLifeDiagram_Spheres_Button_Caption = "SphereOfLifeDiagram_Spheres_Button_Caption";
		public static string SphereOfLifeDiagram_Menu_Save_As_Grp_Template = "SphereOfLifeDiagram_Menu_Save_As_Grp_Template";
		public static string SphereOfLifeDiagram_Menu_Save_As_Org_Template = "SphereOfLifeDiagram_Menu_Save_As_Org_Template";
		public static string SphereOfLifeDiagram_Menu_Del_Grp_Template = "SphereOfLifeDiagram_Menu_Del_Grp_Template";
		public static string SphereOfLifeDiagram_Menu_Del_Org_Template = "SphereOfLifeDiagram_Menu_Del_Org_Template";

		#endregion

		public static string SphereOfLifePopUp_TimeString = "SphereOfLifePopUp_TimeString";
		public static string SphereOfLifePopUp_PositivityString = "SphereOfLifePopUp_PositivityString";

		#region ClassificationEvaluation

		public static string ClassificationEvaluation_DeleteConfirmation = "ClassificationEvaluation_DeleteConfirmation";
		public static string ClassificationEvaluationSearchControl_AddNewNode = "ClassificationEvaluationSearchControl_AddNewNode";
		public static string ClassificationEvaluationSearchControl_EditExistingNode = "ClassificationEvaluationSearchControl_EditExistingNode";
		public static string ClassificationEvaluationSearchControl_CheckBoxUseOrLogic = "ClassificationEvaluationSearchControl_CheckBoxUseOrLogic";
		public static string ClassificationEvaluationSearchControl_Label = "ClassificationEvaluationSearchControl_Label";
		public static string ClassificationEvaluationList_Caption = "ClassificationEvaluationList_Caption";

		#endregion

		public static string EvaluationCommentsHelpText = "EvaluationCommentsHelpText";

		public static string WaitingMessageBeforeLoadingApplication = "WaitingMessageBeforeLoadingApplication";

		public static string DownloadedCompletedMessage = "DownloadedCompletedMessage";
		public static string UploadedCompletedMessage = "UploadedCompletedMessage";


		public static string Medication_ErrorNoEntryTypeSelected = "Medication_ErrorNoEntryTypeSelected";

		public static string ConcurentUsersLimitExceeded = "ConcurentUsersLimitExceeded";

		public static string SessionCreationFailed = "SessionCreationFailed";

		public static string Journal_AddEntry = "Add Journal Entry";
		public static string Journal_RemoveEntry = "Remove Journal Entry";
		public static string Journal_EditEntry = "Edit Journal Entry";

		public static string Journal_AddAttachment = "Add Journal Attachment";
		public static string Journal_RemoveAttachment = "Remove Journal Attachment";
		public static string Journal_CouldNotAttachFile = "Journal_CouldNotAttachFile";

		public static string TitleDescription_AddEntry = "Add Description Title";
		public static string TitleDescription_RemoveEntry = "Remove Description Title";
		public static string TitleDescription_EditEntry = "Edit Description Title";

		public static string General_AddTheme = "Add Theme";
		public static string General_RemoveTheme = "Remove Theme";

		public static string Person_AddEntry = "Add Person";
		public static string Person_RemoveEntry = "Remove Person";
		public static string Person_EditEntry = "Edit Person";
		public static string Person_EditImage = "Edit Person Image";
		public static string Person_EditCategory = "Edit Person Category";
		public static string Person_Update = "Update Person";

		public static string Diagnose_Edit = "Edit Diagnose";
		public static string Evaluation_Edit = "Edit Diagnose";
		public static string DiagnoseEvaluation_Edit = "Edit Diagnose Evaluation";
		public static string DiagnoseEvaluation_Add = "Add Diagnose Evaluation";
		public static string DiagnoseEvaluation_Remove = "Remove Diagnose Evaluation";

		public static string Process_Add = "Add Process";
		public static string Process_Remove = "Remove Process";
		public static string Process_Finished = "Set Process Finished";

		public static string Goal_Move = "Move Goal Definition";
		public static string Goal_Edit = "Edit Goal Definition";
		public static string Goal_Add = "Add Goal Definition";
		public static string Goal_Remove = "Remove Goal Definition";
		public static string Goal_CommentRemove = "Remove Goal Related Comment";
		public static string Goal_CommentAdd = "Add Goal Related Comment";
		public static string Goal_CommentEdit = "Edit Goal Related Comment";


		public static string SOL_RemoveSphereFromDiagram = "Remove Sphere From Diagram";
		public static string SOL_AddSphereToDiagram = "Add Sphere To Diagram";
		public static string SOL_Update_Changes = "Diagram Evaluators Changes";
		public static string SOL_AddSphereRelationship = "Add Sphere Relationship";
		public static string SOL_RemoveSphereRelationship = "Remove Sphere Relationship";

		public static string SOL_RemoveSphereFromSphereList = "Remove Sphere From Sphere List";
		public static string SOL_AddSphereToSphereList = "Add Sphere To Sphere List";

		public static string WaitMessage = "WAIT_MESSAGE";

		public static string HtmlReportApplication_ButtonPrint = "HtmlReportApplication_ButtonPrint";
		public static string HtmlReportApplication_ButtonSave = "HtmlReportApplication_ButtonSave";
		public static string HtmlReportApplication_DropDownLabel = "HtmlReportApplication_DropDownLabel";
		public static string HtmlReportApplication_DropDownHelpText = "HtmlReportApplication_DropDownHelpText";

		public static string AnUnhandledExceptionHasOccured = "AnUnhandledExceptionHasOccured";
		public static string AskForApplicationRestart = "AskForApplicationRestart";
		public static string NoConnectionToServer = "NoConnectionToServer";

		public static string RD_NewPerson_FirstNameHelpText = "RD_NewPerson_FirstNameHelpText";
		public static string RD_NewPerson_LastNameHelpText = "RD_NewPerson_LastNameHelpText";
		public static string New_Person = "New Person";

		public static string ProcessManagement_ContextMenu_OpenReport = "ProcessManagement_ContextMenu_OpenReport";
		public static string ProcessManagement_ContextMenu_Reports = "ProcessManagement_ContextMenu_Reports";
		public static string ProcessManagement_ContextMenu_ToggleShowActivities = "ProcessManagement_ContextMenu_ToggleShowActivities";
		public static string ProcessManagement_ToggleHelpButtonCaption = "ProcessManagement_ToggleHelpButtonCaption";


		public static string AppointmentInfo_Caption = "AppointmentInfo_Caption";
		public static string AppointmentInfo_btnAddAppointment = "AppointmentInfo_btnAddAppointment";
		public static string AppointmentInfo_btnAddAppointmentVisiblePersons = "AppointmentInfo_btnAddAppointmentVisiblePersons";
		public static string AppointmentInfo_Subject = "AppointmentInfo_Subject";
		public static string AppointmentInfo_Participants = "AppointmentInfo_Participants";
		public static string AppointmentInfo_Start = "AppointmentInfo_Start";
		public static string AppointmentInfo_End = "AppointmentInfo_End";
		public static string AppointmentInfo_Reason = "AppointmentInfo_Reason";
		public static string AppointmentInfo_Description = "AppointmentInfo_Description";
		public static string AppointmentInfo_Recurrence = "AppointmentInfo_Recurrence";
		public static string AppointmentInfo_AppointmentType = "AppointmentInfo_AppointmentType";
		public static string AppointmentInfo_All_Day = "AppointmentInfo_All_Day";
		public static string AppointmentInfo_IlegitimateAbsence = "AppointmentInfo_IlegitimateAbsence";
		public static string AppointmentInfo_Reminder = "AppointmentInfo_Reminder";

		public static string Remove_Event_For_All_Participants_Message = "Remove_Event_For_All_Participants_Message";
		public static string Remove_Event_For_Current_Participant = "Remove_Event_For_Current_Participant";
		public static string Remove_Event_For_All_Participants = "Remove_Event_For_All_Participants";
		public static string Remove_Event_For_All_Participants_Including_Other_Groups = "Remove_Event_For_All_Participants_Including_Other_Groups";

		public static string Remove_Recurrent_Event_Message = "Remove_Recurrent_Event_Message";
		public static string Remove_Recurrent_Event_This_Occurrence = "Remove_Recurrent_Event_This_Occurrence";
		public static string Remove_Recurrent_Event_The_Series = "Remove_Recurrent_Event_The_Series";

		public static string Remove_Appointment_Message = "Remove_Appointment_Message";
		public static string ResetCurrentLoadedSheetData = "ResetCurrentLoadedSheetData";

		public static string HtmlReportApplication_btnPrintThroughWordText = "HtmlReportApplication_btnPrintThroughWordText";
		public static string HtmlReportApplication_btnBackText = "HtmlReportApplication_btnBackText";

		public static string HtmlReportApplication_ClientsotGroupSpecific = "HtmlReportApplication_ClientsotGroupSpecific";

		public static string HtmlReportApplication_btnOpenInWordText = "HtmlReportApplication_btnOpenInWordText";
		public static string MenuFile_MenuExtra = "MenuFile_MenuExtra";

		public static string MenuFile_GroupMembership = "MenuFile_GroupMembership";
		public static string SheetNotFound = "SheetNotFound";
		public static string MenuFile_GroupManagement = "MenuFile_GroupManagement";

		public static string MenuFile_ReportManagement = "MenuFile_ReportManagement";
		public static string RemoveGroupMembershipDialogText = "RemoveGroupMembershipDialogText";
		public static string RemoveGroupMembershipUnselectClientInGroupDialogText = "RemoveGroupMembershipUnselectClientInGroupDialogText";

		public static string CannotRemoveGroupMembershipDialogTextSingleMembership = "CannotRemoveGroupMembershipDialogTextSingleMembership";
		public static string CannotRemoveGroupMembershipDialogTextHasHomeGroupEntries = "CannotRemoveGroupMembershipDialogTextHasHomeGroupEntries";
		public static string CannotRemoveGroupMembershipDialogTextIsReferencedInDiagrams = "CannotRemoveGroupMembershipDialogTextIsReferencedInDiagrams";

		public static string FirstTimeNoGroupsWarningMessage = "FirstTimeNoGroupsWarningMessage";
		public static string FirstTimeNoGroupsGroupName = "FirstTimeNoGroupsGroupName";
		public static string FirstTimeNoGroupsFromCaption = "FirstTimeNoGroupsFromCaption";
		public static string FirstTimeNoGroupsFromErrorText = "FirstTimeNoGroupsFromErrorText";
		public static string FirstTimeNoGroupsExceptionText = "FirstTimeNoGroupsExceptionText";
		public static string GroupManagementNewGroupName = "GroupManagementNewGroupName";
		public static string GroupManagementCannotAddChildToDestGroup = "GroupManagementCannotAddChildToDestGroup";
		public static string GroupManagementGroupRemovalNotAllowed = "GroupManagementGroupRemovalNotAllowed";
		public static string GroupManagementCurrentGroupRemovalNotAllowed = "GroupManagementCurrentGroupRemovalNotAllowed";
		public static string GroupManagement_GroupsColumnCaption = "GroupManagement_GroupsColumnCaption";
		public static string GroupManagement_UserModifyRightsColumnCaption = "GroupManagement_UserModifyRightsColumnCaption";
		public static string GroupManagement_GroupUserRightsColumnCaption = "GroupManagement_GroupUserRightsColumnCaption";
		public static string GroupManagement_GroupNameIsNotUniqueDialogText = "GroupManagement_GroupNameIsNotUniqueDialogText";
		public static string GroupManagement_HeaderText = "GroupManagement_HeaderText";
		public static string GroupManagement_ExistingProcessesCaption = "GroupManagement_ExistingProcessesCaption";
		public static string GroupManagement_ExistingProcessesHeaderText = "GroupManagement_ExistingProcessesHeaderText";
		public static string GroupManagement_ExistingProcessesItemTypeText = "GroupManagement_ExistingProcessesItemTypeText";
		public static string GroupManagementThereAreClientsWithJournalHomeGroupEntries = "GroupManagementThereAreClientsWithJournalHomeGroupEntries";
		public static string GroupManagementThereAreDirectGroupUsersReferencing = "GroupManagementThereAreDirectGroupUsersReferencing";
		public static string GroupManagementThereArePersonsWithUniqueGroupMembershipReferencing = "GroupManagementThereArePersonsWithUniqueGroupMembershipReferencing";


		public static string GroupManagement_JournalEntryListCaption = "GroupManagement_JournalEntryListCaption";
		public static string GroupManagement_JournalEntryListHeaderText = "GroupManagement_JournalEntryListHeaderText";
		public static string GroupManagement_JournalEntryItemTypeText = "GroupManagement_JournalEntryItemTypeText";
		public static string GroupManagement_JournalEntryLastChange = "GroupManagement_JournalEntryLastChange";


		public static string GroupMembership_ExistingClients = "GroupMembership_ExistingClients";
		public static string GroupMembership_Clients = "GroupMembership_Clients";
		public static string GroupMembership_NonExistingClients = "GroupMembership_NonExistingClients";

		public static string ReportManagement_DropDownReportsHelp = "ReportManagement_DropDownReportsHelp";
		public static string ReportManagement_HeaderGroupCaption = "ReportManagement_HeaderGroupCaption";
		public static string ReportManagement_HeaderUsersCaption = "ReportManagement_HeaderUsersCaption";
		public static string ReportManagement_HeaderGrantRights = "ReportManagement_HeaderGrantRights";
		public static string ReportManagement_LabelReports = "ReportManagement_LabelReports";
		public static string ReportManagement_SelectAllGroups = "ReportManagement_SelectAllGroups";
		public static string ReportManagement_DeselectAllGroups = "ReportManagement_DeselectAllGroups";
		public static string ReportManagement_SelectAllPersons = "ReportManagement_SelectAllPersons";
		public static string ReportManagement_DeselectAllPersons = "ReportManagement_DeselectAllPersons";

		public static string IssueReportingForm_HelpText = "IssueReportingForm_HelpText";
		public static string Send = "Send";
		public static string IssueReportingForm_Caption = "IssueReportingForm_Caption";
		public static string ApplicationCaption_LockString = "ApplicationCaption_LockString";
		public static string ServerMaximumSessionsExceeded = "ServerMaximumSessionsExceeded";//"The number of maximum allowed sessions must be between 1 and 999"		
		public static string ServerIsDeadMessage = "ServerIsDeadMessage";
		public static string SameUserLoggedInMessage = "SameUserLoggedInMessage";
		public static string SessionExpired = "SessionExpired";
		public static string StartRecordingAnimationForProblemReporting = "StartRecordingAnimationForProblemReporting";
		public static string StopRecordingAnimationForProblemReporting = "StopRecordingAnimationForProblemReporting";
		public static string DontForgetToStopAnnimationMessage = "DontForgetToStopAnnimationMessage";
		public static string Menu_LastUserChange = "Menu_LastUserChange";


		public static string ExcelDocumentsMenu = "ExcelDocumentsMenu";
		public static string WordDocumentsMenu = "WordDocumentsMenu";

		public static string AttachToNewJournalEntry = "AttachToNewJournalEntry";
		public static string AttachmentHasBeenChanged = "AttachmentHasBeenChanged";

		public static string General_SelectClientType = "General_SelectClientType";
		public static string General_AllClientsCategory = "General_AllClientsCategory";
		public static string Category_NoGroupSpecific = "Category_NoGroupSpecific";
		public static string TestVersionWarningFormCaption = "TestVersionWarningFormCaption";
		public static string TestVersionWarningDialogText = "TestVersionWarningDialogText";
		public static string MenuAdditionalHelp = "MenuAdditionalHelp";

		public static string GroupsToActivateChooserDialog_CaptionGropList = "GroupsToActivateChooserDialog_CaptionGropList";
		public static string AdvancedSearch_FilterSortingGridDropDownHelpText = "AdvancedSearch_FilterSortingGridDropDownHelpText";
		public static string AdvancedSearch_AddNameFilterDialogCaption = "AdvancedSearch_AddNameFilterDialogCaption";


		public static string FieldsGrid_DeleteEntryConfirmation = "FieldsGrid_DeleteEntryConfirmation";
		public static string FieldsGrid_NotAllowedToDeleteWarning = "FieldsGrid_NotAllowedToDeleteWarning";
		#region 3.1
		public static string PersonDescriptionEvaluation_Description = "PersonDescriptionEvaluation_Description";
		public static string PersonDescriptionEvaluation_WrittenByCaption = "PersonDescriptionEvaluation_WrittenByCaption";
		public static string PersonDescriptionEvaluation_LastUsedDateCaption = "PersonDescriptionEvaluation_LastUsedDateCaption";
		public static string SelectActionPlanAddNewEntryHelpText = "SelectActionPlanAddNewEntryHelpText";

		public static string UserNotAllowedToOpenApplication = "UserNotAllowedToOpenApplication";
		public static string AreYouSureYouWantTochangeThePersonName = "AreYouSureYouWantTochangeThePersonName";

		public static string GoalDefinition_HelpMultiEntry = "GoalDefinition_HelpMultiEntry";
		public static string GoalDefinition_LabelMultiEntry = "GoalDefinition_LabelMultiEntry";

		public static string JournalItem_ReadBy = "JournalItem_ReadBy";

		public static string ShortProcessInfo_SelectionProcesses = "ShortProcessInfo_SelectionProcesses";
		public static string ShortProcessInfo_StartDateHelpText = "ShortProcessInfo_StartDateHelpText";
		public static string ShortProcessInfo_EndDateHelpText = "ShortProcessInfo_EndDateHelpText";
		public static string ShortProcessInfo_CaptionListProcessesInRange = "ShortProcessInfo_CaptionListProcessesInRange";
		public static string ShortProcessInfo_SelectedProcessBeforeRange = "ShortProcessInfo_SelectedProcessBeforeRange";
		public static string ShortProcessInfo_SelectedProcessInRange = "ShortProcessInfo_SelectedProcessInRange";
		public static string ShortProcessInfo_SelectedProcessAfterRange = "ShortProcessInfo_SelectedProcessAfterRange";

		public static string Person_Membership = "Person_Membership";
		public static string Person_Status = "Person_Status";

		public static string PersonInformation_MessageMatchedPersons = "PersonInformation_MessageMatchedPersons";
		public static string PersonInformation_MessageAddPersonIfMatchesFound = "PersonInformation_MessageAddPersonIfMatchesFound";
		public static string PersonInformation_MessageUserDoesNotHaveRightsOnThisClient = "PersonInformation_MessageUserDoesNotHaveRightsOnThisClient";
		public static string PersonInformation_MessageClickedPersonCannotBeSelected_IsNotClient = "PersonInformation_MessageClickedPersonCannotBeSelected_IsNotClient";
		public static string PersonInformation_MessageClickedPersonDoesNotExistAnymore = "PersonInformation_MessageClickedPersonDoesNotExistAnymore";

		public static string MenuActivateThemeText = "MenuActivateThemeText";
		public static string MenuDeactivateThemeText = "MenuDeactivateThemeText";

		public static string MenuActivateDomainText = "MenuActivateDomainText";
		public static string MenuDeactivateDomainText = "MenuDeactivateDomainText";
		public static string OfficeTemplate_PropertyGridCaption = "OfficeTemplate_PropertyGridCaption";
		public static string OfficeTemplate_TemplateRootCaption = "OfficeTemplate_TemplateRootCaption";
		public static string OfficeTemplate_SelectAll = "OfficeTemplate_SelectAll";
		public static string OfficeTemplate_DeselectAll = "OfficeTemplate_DeselectAll";
		public static string OfficeTemplate_EditInExternalEditor = "OfficeTemplate_EditInExternalEditor";
		public static string OfficeTemplate_GridHeaderGroupsCaption = "OfficeTemplate_GridHeaderGroupsCaption";
		public static string OfficeTemplate_GridHeaderGrantRightsCaption = "OfficeTemplate_GridHeaderGrantRightsCaption";
		public static string OfficeTemplate_NewGroupTemplateNode = "OfficeTemplate_NewGroupTemplateNode";
		public static string OfficeTemplate_NewExcelTemplateNode = "OfficeTemplate_NewExcelTemplateNode";
		public static string OfficeTemplate_NewWordTemplateNode = "OfficeTemplate_NewWordTemplateNode";
		public static string OfficeTemplate_SelectNewTemplateNodeType = "OfficeTemplate_SelectNewTemplateNodeType";
		public static string OfficeTemplate_ScopeCannotBeChanged_TemplateUsed = "OfficeTemplate_ScopeCannotBeChanged_TemplateUsed";
		public static string Are_You_Sure_You_Want_to_Delete_This = "Are_You_Sure_You_Want_to_Delete_This";



		#endregion

		public static string GroupMembership_ValidFromCannotBeLaterThanValidUntil = "GroupMembership_ValidFromCannotBeLaterThanValidUntil";
		public static string GroupMembership_CannotInvalidateTheOnlyExistingMemership = "GroupMembership_CannotInvalidateTheOnlyExistingMemership";
		public static string GroupMembership_CannotOverlapMembershipsOfTheSameGroup = "GroupMembership_CannotOverlapMembershipsOfTheSameGroup";
		public static string GroupMembership_CannotRemoveGroupTheOnlyExistingGroupMembership = "GroupMembership_CannotRemoveGroupTheOnlyExistingGroupMembership";
		public static string GroupMembership_CannotRemoveGroupMembershipForCurrentClientOnCurrentGroup = "GroupMembership_CannotRemoveGroupMembershipForCurrentClientOnCurrentGroup";
		public static string GroupMembership_AreYouSureYouWantToRemoveMemberhip = "GroupMembership_AreYouSureYouWantToRemoveMemberhip";


		public static string PresenceList_MenuDeleteDay = "PresenceList_MenuDeleteDay";
		public static string PresenceList_MenuDeleteWeek = "PresenceList_MenuDeleteWeek";

		public static string DevExpressReportApplication_DropDownHelpText = "DevExpressReportApplication_DropDownHelpText";
		public static string DevExpressReportApplication_ButtonEditCaption = "DevExpressReportApplication_ButtonEditCaption";
		public static string DevExpressReportApplication_ButtonSaveCaption = "DevExpressReportApplication_ButtonSaveCaption";
		public static string DevExpressReportApplication_ButtonViewReportCaption = "DevExpressReportApplication_ButtonViewReportCaption";


    //PIS const
	  public static string DataCannotSaved = "DataCannotSaved";
    public static string DataCannotSavedWhileChangeingApp = "DataCannotSavedWhileChangingApp";
	}
}
