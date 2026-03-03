using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArkaneSystems.MouseJiggler.Controls;

internal sealed class ToggleSwitch : Control
{
    private bool _checked;
    private float _animPos;
    private readonly System.Windows.Forms.Timer _animTimer;

    private static readonly Color ColorOnTrack  = Color.FromArgb(0,   212, 255);
    private static readonly Color ColorOffTrack = Color.FromArgb(45,  55,  72);
    private static readonly Color ColorThumb    = Color.FromArgb(240, 248, 255);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Checked
    {
        get => _checked;
        set
        {
            if (_checked == value) return;
            _checked = value;
            _animTimer.Start();
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler? CheckedChanged;

    public ToggleSwitch()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.SupportsTransparentBackColor, true);

        Size      = new Size(56, 28);
        BackColor = Color.Transparent;
        Cursor    = Cursors.Hand;

        _animTimer = new System.Windows.Forms.Timer { Interval = 12 };
        _animTimer.Tick += AnimTimer_Tick;
    }

    private void AnimTimer_Tick(object? sender, EventArgs e)
    {
        float target = _checked ? 1f : 0f;
        float delta  = target - _animPos;
        if (Math.Abs(delta) < 0.04f)
        {
            _animPos = target;
            _animTimer.Stop();
        }
        else
        {
            _animPos += delta * 0.22f;
        }
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        Checked = !Checked;
        base.OnClick(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode   = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        int   w      = Width;
        int   h      = Height;
        int   r      = h / 2;
        const int pad = 3;
        int   tDia   = h - pad * 2;
        float travel = w - h;

        Color track = LerpColor(ColorOffTrack, ColorOnTrack, _animPos);
        using (var brush = new SolidBrush(track))
            FillRoundRect(g, brush, 0, 0, w, h, r);

        if (_animPos > 0.05f)
        {
            using var glowPen = new Pen(Color.FromArgb((int)(65 * _animPos), ColorOnTrack), 2f);
            DrawRoundRect(g, glowPen, 1, 1, w - 2, h - 2, r - 1);
        }

        float tx = pad + _animPos * travel;
        using (var shadow = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            g.FillEllipse(shadow, tx + 1f, pad + 1f, tDia, tDia);

        using (var thumb = new SolidBrush(ColorThumb))
            g.FillEllipse(thumb, tx, pad, tDia, tDia);
    }

    private static void FillRoundRect(Graphics g, Brush b, float x, float y, float w, float h, float r)
    {
        using var path = BuildRoundRectPath(x, y, w, h, r);
        g.FillPath(b, path);
    }

    private static void DrawRoundRect(Graphics g, Pen pen, float x, float y, float w, float h, float r)
    {
        using var path = BuildRoundRectPath(x, y, w, h, r);
        g.DrawPath(pen, path);
    }

    private static GraphicsPath BuildRoundRectPath(float x, float y, float w, float h, float r)
    {
        float d    = r * 2;
        var   path = new GraphicsPath();
        path.AddArc(x,         y,         d, d, 180, 90);
        path.AddArc(x + w - d, y,         d, d, 270, 90);
        path.AddArc(x + w - d, y + h - d, d, d,   0, 90);
        path.AddArc(x,         y + h - d, d, d,  90, 90);
        path.CloseFigure();
        return path;
    }

    private static Color LerpColor(Color a, Color b, float t)
    {
        t = Math.Clamp(t, 0f, 1f);
        return Color.FromArgb(
            (int)(a.R + (b.R - a.R) * t),
            (int)(a.G + (b.G - a.G) * t),
            (int)(a.B + (b.B - a.B) * t));
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _animTimer.Dispose();
        base.Dispose(disposing);
    }
}
