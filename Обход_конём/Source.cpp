#include <iostream>
#include <vector>
#include <map>
using namespace std;

const int N = 8;
bool board[N][N];
struct Position
{
    int x;
    int y;
};
vector<Position> solution;
1
bool solve(int x, int y)
{
    board[x][y] = true;
    Position tmp = { x, y };
    solution.push_back(tmp);
    if (solution.size() == N * N) {
        return true;
    }

    /*Варианты ходов коня
      .1.2.
      3...4
      ..x..
      5...6
      .7.8.
     */

    const struct
    {
        int dx;
        int dy;
    } moves[] =
    {
        { -1, -2 },
        { 1, -2 },
        { -2, -1 },
        { 2, -1 },
        { -2, 1 },
        { 2, 1 },
        { -1, 2 },
        { 1, 2 }
    };
    multimap<int, int> seq;
    for (size_t i = 0; i < N; ++i)
    {
        const int x0 = x + moves[i].dx;
        const int y0 = y + moves[i].dy;
        int c = 0;
        for (size_t j = 0; j < N; ++j)
        {
            const int x1 = x0 + moves[j].dx;
            const int y1 = y0 + moves[j].dy;
            if (x1 >= 0 && x1 < N &&
                y1 >= 0 && y1 < N &&
                !board[x1][y1])
                ++c;
        }
        seq.insert(pair<int, int>(c, i));
    }
    for (multimap<int, int>::iterator i = seq.begin(); i != seq.end(); ++i)
    {
        const int x0 = x + moves[i->second].dx;
        const int y0 = y + moves[i->second].dy;
        if (x0 >= 0 && x0 < N &&
            y0 >= 0 && y0 < N &&
            !board[x0][y0] &&
            solve(x0, y0))
            return true;
    }

    board[x][y] = false;
    solution.pop_back();
    return false;
}

extern "C" __declspec(dllexport) bool Move(int daske[][8], int a, int b) {
    solve(a, b);
    for (int i = 0; i < 64; i++) {
        daske[solution[i].x][solution[i].y] = i + 1;
    return true;
}
