import { useState } from 'react';
import { useGetChoices, usePlayGame } from '../../hooks';
import { PlayResponse } from '../../models';
import './GameConsole.css';

export const GameConsole = () => {
  const { choices } = useGetChoices();
  const { playGame, isLoading } = usePlayGame();

  const [result, setResult] = useState<PlayResponse | undefined>(undefined);
  const [error, setError] = useState<string | undefined>(undefined);

  const getChoiceName = (id: number) =>
    choices.find((choice) => choice.id === id)?.name || 'Unknown';

  const handleSuccessfulGame = (playResponse: PlayResponse) => {
    setResult(playResponse);
    setError(undefined);
  };

  const handleFailureGame = (errorMessage: string) => {
    setError(errorMessage);
    setResult(undefined);
  };

  const handlePlay = async (playerChoiceId: number) => {
    playGame(
      { player: playerChoiceId },
      handleSuccessfulGame,
      handleFailureGame
    );
  };

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
    <div className="game-container">
      <h2>Choose your fighter</h2>

      <div className="choices">
        {choices.map((choice) => (
          <button
            key={choice.id}
            onClick={() => handlePlay(choice.id)}
            disabled={isLoading}
            className="choice-btn"
          >
            {choice.name}
          </button>
        ))}
      </div>

      {isLoading && (
        <div className="loader" aria-label="Loading game result"></div>
      )}

      {error && <p className="error">{error}</p>}

      {result && !isLoading && (
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
      )}
    </div>
  );
};
