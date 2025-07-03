import { Choice, PlayResponse } from '../../models';
import './GameConsole.css';

interface GameResultsProps {
  result: PlayResponse;
  choices: Choice[];
}

export const GameResults = ({ result, choices }: GameResultsProps) => {
  const getChoiceName = (id: number) =>
    choices.find((choice) => choice.id === id)?.name || 'Unknown';

  const getResultClassName = () => {
    if (!result) return '';
    switch (result.results.toLowerCase()) {
      case 'win':
        return 'result-win';
      case 'lose':
        return 'result-lose';
      case 'tie':
        return 'result-tie';
      default:
        return '';
    }
  };

  return (
    <div className={`result ${getResultClassName()}`}>
      <p>
        <strong>{result.results}</strong>
      </p>
      <p>
        You chose: <strong>{getChoiceName(result.player)}</strong>
      </p>
      <p>
        Computer chose: <strong>{getChoiceName(result.computer)}</strong>
      </p>
    </div>
  );
};
