using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Forms
{
    public partial class DoctrineAndFrameManager : Form
    {
        private List<Doctrine> Doctrines { get; set; }
        private List<Frame> Frames { get; set; }
        private AppDBContext _context = new AppDBContext();
        public DoctrineAndFrameManager()
        {
            InitializeComponent();
            doctrinesListBox.DisplayMember = nameof(Doctrine.Name);
            framesListBox.DisplayMember = nameof(Frame.Name);
        }

        private void DoctrineAndFrameManager_Load(object sender, EventArgs e)
        {
            Doctrines = _context.Doctrines.ToList();
            Frames = _context.Frames.ToList();
            RefreshDoctrinesList();
            RefreshFramesList();
        }

        private void RefreshFramesList()
        {
            framesListBox.Items.Clear();
            if (Frames.Any())
            {
                framesListBox.Items.AddRange(Frames.OrderByDescending(f=>f.Score).ToArray());
            }
            framesListBox.Refresh();
        }

        private void RefreshDoctrinesList()
        {
            doctrinesListBox.Items.Clear();
            if (Doctrines.Any())
            {
                doctrinesListBox.Items.AddRange(Doctrines.OrderByDescending(d=>d.Score).ToArray());
            }
            doctrinesListBox.Refresh();
        }

        private void FramesAddButton_Click(object sender, EventArgs e)
        {
            var frameForm = new FrameForm();
            if (frameForm.ShowDialog() == DialogResult.OK)
            {
                DoctrineAndFrameManager_Load(this, new EventArgs());
            }
        }

        private void DoctrinesAddButton_Click(object sender, EventArgs e)
        {
            var doctrineForm = new DoctrineForm();
            if (doctrineForm.ShowDialog() == DialogResult.OK)
            {
                DoctrineAndFrameManager_Load(this, new EventArgs());
            }
        }

        private void FramesRemoveButton_Click(object sender, EventArgs e)
        {
            var frame = (Frame)framesListBox.SelectedItem;
            _context.Frames.Attach(frame);
            _context.FrameRelations.RemoveRange(_context.FrameRelations.Where(r => r.FrameId == frame.Id));
            _context.Frames.Remove(frame);
            _context.SaveChanges();
            Frames.Remove(frame);
            RefreshFramesList();
        }

        private void DoctrinesRemoveButton_Click(object sender, EventArgs e)
        {
            var doctrine = (Doctrine)doctrinesListBox.SelectedItem;
            _context.Doctrines.Attach(doctrine);
            _context.DoctrineRelations.RemoveRange(_context.DoctrineRelations.Where(r => r.DoctrineId == doctrine.Id));
            _context.Doctrines.Remove(doctrine);
            _context.SaveChanges();
            Doctrines.Remove(doctrine);
            RefreshDoctrinesList();
        }

        private void FramesEditButton_Click(object sender, EventArgs e)
        {
            var frame = (Frame)framesListBox.SelectedItem;
            var frameForm = new FrameForm();
            if (frameForm.ShowForEdit(frame) == DialogResult.OK)
            {
                DoctrineAndFrameManager_Load(this, new EventArgs());
            }
        }

        private void DoctrinesEditButton_Click(object sender, EventArgs e)
        {
            var doctrine = (Doctrine)doctrinesListBox.SelectedItem;
            var doctrineForm = new DoctrineForm();
            if (doctrineForm.ShowForEdit(doctrine) == DialogResult.OK)
            {
                DoctrineAndFrameManager_Load(this, new EventArgs());
            }
        }

        private void FramesMoveUpButton_Click(object sender, EventArgs e)
        {
            var frame = (Frame)framesListBox.SelectedItem;
            _context.Frames.Attach(frame);
            var index = framesListBox.SelectedIndex;
            if (index > 0)
            {
                index -= 1;
                var upperFrame = (Frame)framesListBox.Items[index];
                frame.Score = upperFrame.Score + 1;
                _context.SaveChanges();
                DoctrineAndFrameManager_Load(this, new EventArgs());
                framesListBox.SelectedItem = frame;
            }
        }

        private void DoctrinesMoveUpButton_Click(object sender, EventArgs e)
        {
            var doctrine = (Doctrine)doctrinesListBox.SelectedItem;
            _context.Doctrines.Attach(doctrine);
            var index = doctrinesListBox.SelectedIndex;
            if (index > 0)
            {
                index -= 1;
                var upperdoctrine = (Doctrine)doctrinesListBox.Items[index];
                doctrine.Score = upperdoctrine.Score + 1;
                _context.SaveChanges();
                DoctrineAndFrameManager_Load(this, new EventArgs());
                doctrinesListBox.SelectedItem = doctrine;
            }
        }

        private void FramesMoveDownButton_Click(object sender, EventArgs e)
        {
            var frame = (Frame)framesListBox.SelectedItem;
            _context.Frames.Attach(frame);
            var index = framesListBox.SelectedIndex;
            if (index < framesListBox.Items.Count - 1)
            {
                index += 1;
                var bottomFrame = (Frame)framesListBox.Items[index];
                frame.Score = bottomFrame.Score - 1;
                _context.SaveChanges();
                DoctrineAndFrameManager_Load(this, new EventArgs());
                framesListBox.SelectedItem = frame;
            }
        }

        private void DoctrinesMoveDownButton_Click(object sender, EventArgs e)
        {
            var doctrine = (Doctrine)doctrinesListBox.SelectedItem;
            _context.Doctrines.Attach(doctrine);
            var index = doctrinesListBox.SelectedIndex;
            if (index < doctrinesListBox.Items.Count - 1)
            {
                index += 1;
                var bottomdoctrine = (Doctrine)doctrinesListBox.Items[index];
                doctrine.Score = bottomdoctrine.Score - 1;
                _context.SaveChanges();
                DoctrineAndFrameManager_Load(this, new EventArgs());
                doctrinesListBox.SelectedItem = doctrine;
            }
        }
    }
}
