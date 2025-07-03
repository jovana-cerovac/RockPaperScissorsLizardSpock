import { useDeleteAllGameRounds, useGetScoreboardRows } from '../../hooks';
import { ScoreboardRow } from '../../models';
import './Scoreboard.css';

export const Scoreboard = () => {
  const { scoreboardRows, isLoading } = useGetScoreboardRows();
  const { deleteAllGameRounds } = useDeleteAllGameRounds();

  const handleReset = async () => {
    deleteAllGameRounds();
  };

  return (
    <div className="scoreboard-container">
      <h3>Latest 10 Game Rounds</h3>

      {isLoading && <p>Loading rounds...</p>}

      {!isLoading && scoreboardRows.length === 0 && (
        <p>No rounds played yet.</p>
      )}

      {!isLoading && scoreboardRows.length > 0 && (
        <table className="scoreboard-table">
          <thead>
            <tr>
              <th>#</th>
              <th>Player Choice</th>
              <th>Computer Choice</th>
              <th>Result</th>
              <th>Played At</th>
            </tr>
          </thead>
          <tbody>
            {!isLoading &&
              scoreboardRows.map((round: ScoreboardRow, index: number) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{round.playerChoice}</td>
                  <td>{round.computerChoice}</td>
                  <td>{round.outcomeMessage}</td>
                  <td>{round.playedAt.toLocaleString()}</td>
                </tr>
              ))}
          </tbody>
        </table>
      )}

      <button
        className="reset-btn"
        onClick={handleReset}
        disabled={isLoading || scoreboardRows.length === 0}
      >
        Reset scoreboard
      </button>
    </div>
  );
};
