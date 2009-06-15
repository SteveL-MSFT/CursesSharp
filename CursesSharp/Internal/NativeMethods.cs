#region Copyright 2009 Robert Konklewski

/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace CursesSharp.Internal
{
    internal delegate int RipOffLineFunInt(IntPtr win, int cols);

#if NCURSES_MOUSE_VERSION
    [StructLayout(LayoutKind.Sequential)]
    internal struct WrapMEvent
    {
        internal int id;
        internal int x;
        internal int y;
        internal int z;
        internal uint bstate;
    };
#endif

    internal static class NativeMethods
    {
        #region addch.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_waddch(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwaddch(IntPtr win, int y, int x, uint ch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wechochar(IntPtr win, uint ch);
        #endregion

        #region addchstr.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_waddchnstr(IntPtr win, uint[] chstr, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwaddchnstr(IntPtr win, int y, int x, uint[] chstr, int n);
        #endregion

        #region addstr.c
#if HAVE_USE_WIDECHAR
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_waddnwstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvwaddnwstr(IntPtr win, int y, int x, String str, int n);
#else
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_waddnstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_mvwaddnstr(IntPtr win, int y, int x, String str, int n);
#endif
        #endregion

        #region attr.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wattroff(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wattron(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wattrset(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wstandend(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wstandout(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wcolor_set(IntPtr win, short color_pair);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wattr_get(IntPtr win, out uint attrs, out short color_pair);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wchgat(IntPtr win, int n, uint attr, short color);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color);
        #endregion

        #region beep.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_beep();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_flash();
        #endregion

        #region bkgd.c
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_getbkgd(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wbkgd(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_wbkgdset(IntPtr win, uint ch);
        #endregion

        #region border.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wborder(IntPtr win, uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_box(IntPtr win, uint verch, uint horch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_whline(IntPtr win, uint ch, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wvline(IntPtr win, uint ch, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwhline(IntPtr win, int y, int x, uint ch, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwvline(IntPtr win, int y, int x, uint ch, int n);
        #endregion

        #region clear.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wclear(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_werase(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wclrtobot(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wclrtoeol(IntPtr win);
        #endregion

        #region color.c
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_COLOR_PAIR(int n);
        [DllImport("CursesWrapper")]
        internal static extern short wrap_PAIR_NUMBER(uint n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_start_color();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_init_pair(short color, short fg, short bg);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_init_color(short color, short red, short green, short blue);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_color_content(short color, out short red, out short green, out short blue);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_pair_content(short pair, out short fg, out short bg);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_colors();
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_can_change_color();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_assume_default_colors(int f, int b);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_use_default_colors();
        #endregion

        #region debug.c
        [DllImport("CursesWrapper")]
        internal static extern void wrap_traceon();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_traceoff();
        #endregion

        #region delch.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wdelch(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwdelch(IntPtr win, int y, int x);
        #endregion

        #region deleteln.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wdeleteln(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_winsdelln(IntPtr win, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_winsertln(IntPtr win);
        #endregion

        #region getch.c
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_wgetch(IntPtr win);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_mvwgetch(IntPtr win, int y, int x);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_ungetch(int ch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_flushinp();
        #endregion

        #region getstr.c
#if HAVE_USE_WIDECHAR
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_wgetn_wstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvwgetn_wstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_wgetnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
        #endregion

        #region getyx.c
        [DllImport("CursesWrapper")]
        internal static extern void wrap_getyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_getparyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_getbegyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_getmaxyx(IntPtr win, out int y, out int x);
        #endregion

        #region inch.c
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_winch(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_mvwinch(IntPtr win, int y, int x);
        #endregion

        #region inchstr.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_winchnstr(IntPtr win, uint[] ch, int n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n);
        #endregion

        #region initscr.c
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_initscr();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_endwin();
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_isendwin();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_resize_term(int nlines, int ncols);
        #endregion

        #region inopts.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_cbreak();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nocbreak();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_echo();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_noecho();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_halfdelay(int tenths);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_intrflush(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_keypad(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_meta(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nl();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nonl();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nodelay(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_raw();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_noraw();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_qiflush();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_noqiflush();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_notimeout(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_wtimeout(IntPtr win, int delay);
        #endregion

        #region insch.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_winsch(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwinsch(IntPtr win, int y, int x, uint ch);
        #endregion

        #region insstr.c
#if HAVE_USE_WIDECHAR
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_wins_nwstr(IntPtr win, String wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvwins_nwstr(IntPtr win, int y, int x, String wstr, int n);
#else
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_winsnstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_mvwinsnstr(IntPtr win, int y, int x, String str, int n);
#endif
        #endregion

        #region instr.c
#if HAVE_USE_WIDECHAR
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_winnwstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvwinnwstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_winnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
        #endregion

        #region kernel.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_def_prog_mode();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_def_shell_mode();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_reset_prog_mode();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_reset_shell_mode();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_resetty();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_savetty();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_getsyx(out int y, out int x);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_setsyx(int y, int x);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_ripoffline(int line, RipOffLineFunInt init);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_napms(int ms);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_curs_set(int visibility);
        #endregion

        #region keyname.c
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_keyname(int key);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_key(int key);
        #endregion

        #region mouse.c
#if NCURSES_MOUSE_VERSION
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_mouse();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_getmouse(out WrapMEvent wrap_mevent);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_ungetmouse(ref WrapMEvent wrap_mevent);
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_mousemask(uint mask, out uint oldmask);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_wenclose(IntPtr win, int y, int x);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_wmouse_trafo(IntPtr win, ref int y, ref int x, Boolean to_screen);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mouseinterval(int wait);
#endif
        #endregion

        #region move.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wmove(IntPtr win, int y, int x);
        #endregion

        #region outopts.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_clearok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_idlok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_idcok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_immedok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_leaveok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wsetscrreg(IntPtr win, int top, int bot);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_scrollok(IntPtr win, Boolean bf);
        #endregion

        #region overlay.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_overlay(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_overwrite(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, Boolean overlay);
        #endregion

        #region pad.c
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_newpad(int nlines, int ncols);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_subpad(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_pechochar(IntPtr pad, uint ch);
        #endregion

        #region panel.c
#if HAVE_PANEL_H
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_new_panel(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_bottom_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_top_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_show_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_update_panels();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_hide_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_panel_window(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_replace_panel(IntPtr pan, IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_move_panel(IntPtr pan, int starty, int startx);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_panel_hidden(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_panel_above(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_panel_below(IntPtr pan);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_del_panel(IntPtr pan);
#endif
        #endregion

        #region refresh.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wrefresh(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wnoutrefresh(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_doupdate();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_redrawwin(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wredrawln(IntPtr win, int beg_line, int num_lines);
        #endregion

        #region scr_dump.c
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_scr_dump(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_scr_init(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_scr_restore(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_scr_set(String filename);
        #endregion

        #region scroll.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_scroll(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wscrl(IntPtr win, int n);
        #endregion

        #region slk.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_init(int fmt);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_refresh();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_noutrefresh();
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_slk_label(int labnum);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_clear();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_restore();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_touch();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_attron(uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_attrset(uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_attroff(uint attrs);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_slk_color(short color_pair);
#if HAVE_USE_WIDECHAR
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_slk_wset(int labnum, String label, int justify);
#else
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern int wrap_slk_set(int labnum, String label, int justify);
#endif
        #endregion

        #region termattr.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_baudrate();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern char wrap_erasechar();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        internal static extern char wrap_killchar();
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_termattrs();
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_ic();
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_il();
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_termname();
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_longname();
        #endregion

        #region touch.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_touchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_touchline(IntPtr win, int start, int count);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_untouchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_wtouchln(IntPtr win, int y, int n, int changed);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_is_linetouched(IntPtr win, int line);
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_is_wintouched(IntPtr win);
        #endregion

        #region util.c
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_unctrl(uint c);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_filter();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_use_env(Boolean x);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_delay_output(int ms);
        #endregion

        #region window.c
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_newwin(int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_derwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_subwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_dupwin(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_delwin(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvwin(IntPtr win, int y, int x);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvderwin(IntPtr win, int pary, int parx);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_syncok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_wsyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_wcursyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern void wrap_wsyncdown(IntPtr win);
        #endregion

        #region wrapper.c
        [DllImport("CursesWrapper")]
        internal static extern int wrap_LINES();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_COLS();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_COLORS();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_COLOR_PAIRS();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_TABSIZE();
        #endregion
    }
}