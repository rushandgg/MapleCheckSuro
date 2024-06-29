using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Vml;

namespace MapleCheckSuro
{
    public partial class CharacterForm : Form
    {
        private MainForm mainForm;

        public CharacterForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddList();
        }

        private void AddList()
        {
            if (mainChaTB != null && subChaTB != null)
            {
                string[] subArray = subChaTB.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string mainCharacter = mainChaTB.Text;
                for (int i = 0; i < subArray.Length; i++)
                {
                    string subCharacter = subArray[i];
                    if (mainForm.heroDict.ContainsKey(subCharacter))
                    {

                    }
                    else
                    {
                        mainForm.heroDict.Add(subCharacter, mainCharacter);
                    }
                }
                // 입력했던 컨트롤 초기화
                mainChaTB.Text = "";
                subChaTB.Text = "";

                // ListBox에 목록 표시하기
                ShowListBox();
            }
        }

        private void ShowListBox()
        {
            characterLB.Items.Clear(); // listBox 초기화

            if (mainForm.heroDict.Count > 0)
            {
                // 값을 기준으로 그룹화하여 출력
                var groupedByKey = mainForm.heroDict.GroupBy(kvp => kvp.Value);

                // 그룹화된 결과를 출력
                foreach (var group in groupedByKey)
                {
                    string allHero = group.Key + " : ";

                    foreach (var kvp in group)
                    {
                        allHero += kvp.Key + " ";

                    }

                    characterLB.Items.Add(allHero);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (mainForm.heroDict.Count > 0)
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = System.IO.Path.Combine(myDocumentsPath, "꿈터달성캐릭.txt");

                try
                {
                    // StreamWriter를 사용하여 UTF-8 형식으로 파일 쓰기
                    using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        foreach (var item in characterLB.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show($"저장되었습니다.\n파일 경로: {filePath}", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"파일 저장 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void subChaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddList();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            characterLB.Items.Clear(); // listBox 초기화
            mainForm.heroDict.Clear();
            MessageBox.Show("초기화 되었습니다.");
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(myDocumentsPath, "꿈터달성캐릭.txt");

            try
            {
                // 파일에서 데이터 읽기
                string[] lines = File.ReadAllLines(filePath);

                // Dictionary 초기화
                mainForm.heroDict.Clear();

                // 데이터를 Dictionary에 저장
                foreach (string line in lines)
                {
                    int delimiterIndex = line.IndexOf(" : ");
                    if (delimiterIndex != -1)
                    {
                        string mainCharacter = line.Substring(0, delimiterIndex).Trim();
                        string subCharactersPart = line.Substring(delimiterIndex + 3).Trim();
                        string[] subCharacters = subCharactersPart.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        // Dictionary에 추가
                        for (int i = 0; i < subCharacters.Length; i++) 
                        {
                            mainForm.heroDict.Add(subCharacters[i], mainCharacter);
                        }
                    }
                }

                // ListBox에 데이터 표시
                ShowListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 읽기 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (characterLB.SelectedItem != null)
            {
                string selectedItem = characterLB.SelectedItem.ToString();

                int delimiterIndex = selectedItem.IndexOf(" : ");
                if (delimiterIndex != -1)
                {
                    string mainCharacter = selectedItem.Substring(0, delimiterIndex).Trim();
                    string subCharactersPart = selectedItem.Substring(delimiterIndex + 3).Trim();
                    //string[] subCharacters = subCharactersPart.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    mainChaTB.Text = mainCharacter;
                    subChaTB.Text = subCharactersPart;
                }
            }
        }
    }
}
