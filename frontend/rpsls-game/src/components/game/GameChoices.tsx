import { Choice } from '../../models';
import './GameConsole.css';

interface GameChoicesProps {
  choices: Choice[];
  disabled: boolean;
  onPick: (choice: Choice) => void;
}

export const GameChoices = ({
  choices,
  disabled,
  onPick
}: GameChoicesProps) => {
  return (
    <div>
      <h2>Choose your fighter:</h2>
      <div className="choices">
        {choices.map((choice) => (
          <button
            key={choice.id}
            onClick={() => onPick(choice)}
            disabled={disabled}
            className="choice-btn"
          >
            {choice.name}
          </button>
        ))}
      </div>
    </div>
  );
};
