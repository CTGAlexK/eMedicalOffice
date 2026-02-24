Imports System.Runtime.InteropServices
Module RemoveTreeViewNodeCheckBox



    Public Const TVIF_STATE As Integer = &H8
    Public Const TVIS_STATEIMAGEMASK As Integer = &HF000
    Public Const TV_FIRST As Integer = &H1100
    Public Const TVM_SETITEM As Integer = TV_FIRST + 63


    <StructLayout(LayoutKind.Sequential)> Public Structure TVITEM
        Public mask As Integer
        Public hItem As IntPtr
        Public state As Integer
        Public stateMask As Integer
        <MarshalAs(UnmanagedType.LPTStr)> Public lpszText As String
        Public cchTextMax As Integer
        Public iImage As Integer
        Public iSelectedImage As Integer
        Public cChildren As Integer
        Public lParam As IntPtr
    End Structure


    Public Declare Auto Function SendMessage Lib "User32.dll" (ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByRef lParam As TVITEM) As Integer
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As IntPtr, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

    Public Sub TreeNode_SetStateImageIndex(ByVal node As TreeNode, ByVal index As Integer)
        Dim tvi As TVITEM = Nothing
        tvi.hItem = node.Handle
        tvi.mask = TVIF_STATE
        tvi.stateMask = TVIS_STATEIMAGEMASK
        tvi.state = index << 12
        SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, tvi)
    End Sub


End Module
