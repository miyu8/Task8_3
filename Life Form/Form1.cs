using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Life.Initialization;
using Life.BaseData;
using Life;
using System.Threading;
using Life_Form.GameForm;
using Life.Gaming;

namespace Life_Form
{
    public partial class Form1 : Form
    {
        public delegate void textBox1Changes(string text);
        public event textBox1Changes TextBox1Change;
        public delegate void dataGridView1Changes();
        public event dataGridView1Changes DataGridView1Change;
        public delegate void stopGame();
        public event stopGame StopGame;

        public void TextBoxChanged(string text)
        {
            TextBox1Change?.Invoke(text);
        }

        public void dataGridViewChanged()
        {
            DataGridView1Change?.Invoke();
        }

        public void StopChanged()
        {
            StopGame?.Invoke();
        }

        public Options options;
        public Thread gameThread;
        public bool exit;
        DataModelContainer db;
        RecordBase recordBase = new RecordBase();
        JSON jSON = new JSON();
        public GameBase igame;
        public GameBaseForm gameBaseForm;
        public ServerInit serverInit;
        DataGridView dataGridView;
        Form savingsForm;
        GameService.LifeServiceClient service = new GameService.LifeServiceClient("BasicHttpBinding_ILifeService");

        public Form1()
        {
            InitializeComponent();
            options = jSON.GetJson();
            //serverInit = new ServerInit(options);
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.RowCount = options.gameProperty.SizeX;
            dataGridView1.ColumnCount = options.gameProperty.SizeY;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            StartGame(1);
        }

        public void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            StopGame += WriteGame;
            StopChanged();
        }

        private void ClickDataGrid()
        {
            dataGridView = CreateDataGridView();
            FillDataView(dataGridView);
            savingsForm = new Form();
            savingsForm.Width = 600;
            savingsForm.Height = 1000;
            dataGridView.Width = 600;
            dataGridView.Height = 1000;
            savingsForm.Controls.Add(dataGridView);
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ClickDataGrid();
            dataGridView.CellDoubleClick += dataGridView_MouseDoubleClick;
            savingsForm.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ClickDataGrid();
            dataGridView.CellContentClick += DataGridViewCell_Click;
            savingsForm.ShowDialog();
            MessageBox.Show("Выбранная игра удалена");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            StartGame(2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            StartGame(3);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            StartGame(4);
        }

        private DataGridView CreateDataGridView()
        {
            DataGridView dataGridView;
            dataGridView = new DataGridView();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            return dataGridView;
        }

        private void FillDataView(DataGridView dataGridView)
        {
            int i, count;
            try
            {
                using (db = new DataModelContainer())
                {
                    db.Database.CreateIfNotExists();
                    count = db.GameSet.Count();
                    if (count != 0)
                    {
                        dataGridView.RowCount = count;
                        dataGridView.ColumnCount = 5;
                        i = 0;
                        foreach (var item in db.GameSet)
                        {
                            dataGridView[0, i].Value = item.Id;
                            dataGridView[1, i].Value = item.Type;
                            dataGridView[2, i].Value = item.Iteration;
                            dataGridView[3, i].Value = item.SizeX;
                            dataGridView[4, i].Value = item.SizeY;
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }

        private void dataGridView_MouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = ((DataGridView)sender);
            int i = e.RowIndex;
            int id = (int)dataGridView[0, i].Value;
            int type = (int)dataGridView[1, i].Value;
            int iteration = (int)dataGridView[2, i].Value;
            ((Form)((DataGridView)sender).Parent).Close();
            SaveGame(id, type, iteration);
        }

        private void DataGridViewCell_Click(object sender, DataGridViewCellEventArgs e)
        {
            int count;
            try
            {
                using (db = new DataModelContainer())
                {
                    db.Database.CreateIfNotExists();
                    count = db.GameSet.Count();
                    if (count != 0)
                    {
                        serverInit.Remove(db.GameSet.ToList().ElementAt(e.RowIndex).Id);
                        ((Form)((DataGridView)sender).Parent).Close();
                    }
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }

        private void SaveGame(int id, int type, int iteration)
        {
            exit = false;
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem8.Enabled = false;
            gameThread = new Thread(() =>
            {
                MoveForm(type);
                service.RunSave(options,id, iteration, igame);
                //serverInit.RunSave(id, iteration, igame);
                Begin();
                Active();
            });
            gameThread.Start();
        }

        private void StartGame(int type)
        {
            exit = false;
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem8.Enabled = false;
            
            //service.Game1New();
            gameThread = new Thread(() =>
            {
                //service = new GameService.LifeServiceClient("BasicHttpBinding_ILifeService");
                MoveForm(type);
                service.RunNew(igame);
                //serverInit.RunNew(igame);
                Begin();
                Active();
            });
            gameThread.Start();
        }

        public void WriteTextBox(string text)
        {
            if (textBox1.InvokeRequired)
                textBox1.Invoke((MethodInvoker)(() => Write(text)));
            else
                Write(text);
        }

        private void Write(string text)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Clear();
            textBox1.AppendText(text);
        }

        public void WriteDataGridView()
        {
            if (dataGridView1.InvokeRequired)
                dataGridView1.Invoke((MethodInvoker)(() => WriteDataGrid()));
            else
                WriteDataGrid();
        }

        private void WriteDataGrid()
        {
            dataGridView1.Show();
        }

        public void WriteGame()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)(() => WriteStop()));
            else
                WriteStop();
        }

        private void WriteStop()
        {
            exit = true;
        }

        public void Active()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)(() => WriteActive()));
            else
                WriteActive();
        }

        private void WriteActive()
        {
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem8.Enabled = true;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        public void MoveForm(int type)
        {
            switch (type)
            {
                case 1:
                    igame = service.Game1New(options);//serverInit.Game1New();
                    gameBaseForm = new Game1Form(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name, this);
                    break;
                case 2:
                    igame = service.Game2New(options);//serverInit.Game2New();
                    gameBaseForm = new Game2Form(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name, this);
                    break;
                case 3:
                    igame = service.Game3New(options);//serverInit.Game3New();
                    gameBaseForm = new Game3Form(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name, this);
                    break;
                case 4:
                    igame = service.Game4New(options);//serverInit.Game4New();
                    gameBaseForm = new Game4Form(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name, this);
                    break;
            }
        }

        public void Begin()
        {

            gameBaseForm.DrawForm(igame.gameField, igame.iteration, igame.ValueCells);
            Thread.Sleep(500);
            if (exit)
            {
                service.End(igame);//serverInit.End(igame);
                return;
            }
            while (service.Step(igame))//serverInit.Step(igame))
            {
                gameBaseForm.ClearNumbers();
                gameBaseForm.DrawForm(igame.gameField, igame.iteration, igame.ValueCells);
                Thread.Sleep(500);
                if (exit)
                {
                    service.End(igame);//serverInit.End(igame);
                    gameBaseForm.ClearTable();
                    MessageBox.Show("Игра остановлена и сохранена");
                    return;
                }
            }
            gameBaseForm.ClearTable();
            MessageBox.Show("Игра окончена");
        }
    }
}
