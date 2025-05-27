using ExpectedObjects;
using NeetCode.LinkedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace NeetCode.Arrays
{
    //https://leetcode.com/problems/valid-sudoku/
    public class IsValidSudokuSolution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (!ValidRow(i, board) || !ValidColumn(i, board))
                    return false;
            }

            for (int i = 0; i < board.Length; i += 3)
            {
                for (int j = 0; j < board[0].Length; j += 3)
                {
                    if (!ValidSquare(i, j, board))
                        return false;
                }
            }

            return true;
        }

        private bool ValidSquare(int x, int y, char[][] board)
        {
            var hashSet = new HashSet<char>();

            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    char character = board[i][j];
                    if (character != '.' && !hashSet.Add(character))
                        return false;
                }
            }

            return true;
        }

        private bool ValidColumn(int x, char[][] board)
        {
            var hashSet = new HashSet<char>();

            for (int i = 0; i < board.Length; i++)
            {
                char ch = board[i][x];
                if (ch != '.' && !hashSet.Add(ch))
                    return false;
            }

            return true;
        }

        private bool ValidRow(int y, char[][] board)
        {
            var hashSet = new HashSet<char>();

            for (int i = 0; i < board[0].Length; i++)
            {
                char ch = board[y][i];
                if (ch != '.' && !hashSet.Add(ch))
                    return false;
            }

            return true;
        }


        [Fact]
        public async Task Test1()
        {
            var input = new char[][] {
                new char[]{ '1', '2', '.', '.', '3', '.', '.', '.', '.' },
                new char[]{ '4', '.', '.', '5', '.', '.', '.', '.', '.' },
                new char[]{ '.', '9', '8', '.', '.', '.', '.', '.', '3' },
                new char[]{ '5', '.', '.', '.', '6', '.', '.', '.', '4' },
                new char[]{ '.', '.', '.', '8', '.', '3', '.', '.', '5' },
                new char[]{ '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[]{ '.', '.', '.', '.', '.', '.', '2', '.', '.' },
                new char[]{ '.', '.', '.', '4', '1', '9', '.', '.', '8' },
                new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Assert.True(IsValidSudoku(input));
        }

        [Fact]
        public async Task Test2()
        {
            var input = new char[][]
            {
                new char[]{'1', '2', '.', '.', '3', '.', '.', '.', '.'},
                new char[]{'4', '.', '.', '5', '.', '.', '.', '.', '.'},
                new char[]{'.', '9', '1', '.', '.', '.', '.', '.', '3'},
                new char[]{'5', '.', '.', '.', '6', '.', '.', '.', '4'},
                new char[]{'.', '.', '.', '8', '.', '3', '.', '.', '5'},
                new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[]{'.', '.', '.', '.', '.', '.', '2', '.', '.'},
                new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '8'},
                new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };


            Assert.False(IsValidSudoku(input));
        }

        [Fact]
        public async Task Test3()
        {
            var input = new char[][]
            {
                new char[]{ '.', '.', '.', '.', '5', '.', '.', '1', '.'},
                new char[]{ '.', '4', '.', '3', '.', '.', '.', '.', '.'},
                new char[]{ '.', '.', '.', '.', '.', '3', '.', '.', '1'},
                new char[]{ '8', '.', '.', '.', '.', '.', '.', '2', '.'},
                new char[]{ '.', '.', '2', '.', '7', '.', '.', '.', '.'},
                new char[]{ '.', '1', '5', '.', '.', '.', '.', '.', '.'},
                new char[]{ '.', '.', '.', '.', '.', '2', '.', '.', '.'},
                new char[]{ '.', '2', '.', '9', '.', '.', '.', '.', '.'},
                new char[]{ '.', '.', '4', '.', '.', '.', '.', '.', '.'}
            };

            Assert.False(IsValidSudoku(input));
        }



    }
}