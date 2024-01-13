namespace PersonalDataMultiForm;

partial class CreateForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        txtName = new TextBox();
        txtAge = new TextBox();
        cmbGender = new ComboBox();
        btnCreate = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(21, 31);
        label1.Name = "label1";
        label1.Size = new Size(49, 20);
        label1.TabIndex = 0;
        label1.Text = "Name";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(21, 92);
        label2.Name = "label2";
        label2.Size = new Size(57, 20);
        label2.TabIndex = 1;
        label2.Text = "Gender";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(25, 153);
        label3.Name = "label3";
        label3.Size = new Size(36, 20);
        label3.TabIndex = 2;
        label3.Text = "Age";
        // 
        // txtName
        // 
        txtName.Location = new Point(88, 28);
        txtName.Name = "txtName";
        txtName.Size = new Size(198, 27);
        txtName.TabIndex = 3;
        // 
        // txtAge
        // 
        txtAge.Location = new Point(88, 150);
        txtAge.Name = "txtAge";
        txtAge.Size = new Size(134, 27);
        txtAge.TabIndex = 4;
        // 
        // cmbGender
        // 
        cmbGender.FormattingEnabled = true;
        cmbGender.Location = new Point(88, 89);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new Size(160, 28);
        cmbGender.TabIndex = 5;
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(288, 205);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(94, 29);
        btnCreate.TabIndex = 6;
        btnCreate.Text = "Create";
        btnCreate.UseVisualStyleBackColor = true;
        // 
        // CreateForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(452, 267);
        Controls.Add(btnCreate);
        Controls.Add(cmbGender);
        Controls.Add(txtAge);
        Controls.Add(txtName);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "CreateForm";
        Text = "CreateForm";
        Load += CreateForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox txtName;
    private TextBox txtAge;
    private ComboBox cmbGender;
    private Button btnCreate;
}