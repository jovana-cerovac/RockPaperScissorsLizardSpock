import { useDeleteAllGameRounds } from '../../hooks';
import './Scoreboard.css';

interface ResetButtonProps {
  disabled: boolean;
}

export const ResetButton = ({ disabled }: ResetButtonProps) => {
  const { deleteAllGameRounds } = useDeleteAllGameRounds();

  const handleReset = async () => {
    deleteAllGameRounds();
  };

  return (
    <button className="reset-btn" onClick={handleReset} disabled={disabled}>
      Reset scoreboard
    </button>
  );
};
