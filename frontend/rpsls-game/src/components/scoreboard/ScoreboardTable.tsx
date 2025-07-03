import { ScoreboardRow } from '../../models';
import './Scoreboard.css';

interface ScoreboardTableProps {
  scoreboardRows: ScoreboardRow[];
}

export const ScoreboardTable = ({ scoreboardRows }: ScoreboardTableProps) => {
  return (
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
        {scoreboardRows.map((round: ScoreboardRow, index: number) => {
          let resultClass = '';
          if (round.outcomeMessage === 'WIN') resultClass = 'result-win';
          else if (round.outcomeMessage === 'LOSE') resultClass = 'result-lose';
          else resultClass = 'result-tie';

          return (
            <tr key={index}>
              <td>{index + 1}</td>
              <td>{round.playerChoice}</td>
              <td>{round.computerChoice}</td>
              <td className={resultClass}>{round.outcomeMessage}</td>
              <td>{round.playedAt.toLocaleString()}</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};
