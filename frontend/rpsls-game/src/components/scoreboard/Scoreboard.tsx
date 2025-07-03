import { useGetScoreboardRows } from '../../hooks';
import { ErrorMessage, Loader, ScoreboardTable, ResetButton } from '..';
import './Scoreboard.css';

export const Scoreboard = () => {
  const { scoreboardRows, isLoading } = useGetScoreboardRows();

  return (
    <div className="scoreboard-container">
      <h3>Scoreboard</h3>
      {isLoading && <Loader message="Loading rounds..." />}
      {!isLoading && scoreboardRows.length === 0 && (
        <ErrorMessage message="No rounds played yet." />
      )}
      {!isLoading && scoreboardRows.length > 0 && (
        <ScoreboardTable scoreboardRows={scoreboardRows} />
      )}
      <ResetButton disabled={isLoading || scoreboardRows.length === 0} />
    </div>
  );
};
