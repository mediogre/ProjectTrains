﻿namespace Trains
{
    partial class TrnResultByNumber
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultNumber = new System.Windows.Forms.Label();
            this.ResultPlaceDepart = new System.Windows.Forms.Label();
            this.ResultPlaceArrive = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер поезда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пункт отправления";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пункт прибытия";
            // 
            // ResultNumber
            // 
            this.ResultNumber.AutoSize = true;
            this.ResultNumber.Location = new System.Drawing.Point(203, 50);
            this.ResultNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultNumber.Name = "ResultNumber";
            this.ResultNumber.Size = new System.Drawing.Size(51, 20);
            this.ResultNumber.TabIndex = 3;
            this.ResultNumber.Text = "label4";
            // 
            // ResultPlaceDepart
            // 
            this.ResultPlaceDepart.AutoSize = true;
            this.ResultPlaceDepart.Location = new System.Drawing.Point(203, 70);
            this.ResultPlaceDepart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultPlaceDepart.Name = "ResultPlaceDepart";
            this.ResultPlaceDepart.Size = new System.Drawing.Size(51, 20);
            this.ResultPlaceDepart.TabIndex = 4;
            this.ResultPlaceDepart.Text = "label5";
            // 
            // ResultPlaceArrive
            // 
            this.ResultPlaceArrive.AutoSize = true;
            this.ResultPlaceArrive.Location = new System.Drawing.Point(203, 90);
            this.ResultPlaceArrive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultPlaceArrive.Name = "ResultPlaceArrive";
            this.ResultPlaceArrive.Size = new System.Drawing.Size(51, 20);
            this.ResultPlaceArrive.TabIndex = 5;
            this.ResultPlaceArrive.Text = "label6";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TrnResultByNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 123);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResultPlaceArrive);
            this.Controls.Add(this.ResultPlaceDepart);
            this.Controls.Add(this.ResultNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TrnResultByNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты поиска поезда по его номеру";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label ResultNumber;
        public System.Windows.Forms.Label ResultPlaceDepart;
        public System.Windows.Forms.Label ResultPlaceArrive;
    }
}