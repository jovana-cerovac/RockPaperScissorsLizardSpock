import { useState } from 'react';
import { useGetChoices, usePlayGame } from '../../hooks';
import { Choice, PlayResponse } from '../../models';
import {
  GameResults,
  RandomChoicePicker,
  GameChoices,
  ResultsLoader,
  ErrorMessage
} from '..';
import './GameConsole.css';

export const GameConsole = () => {
  const { choices } = useGetChoices();
  const { playGame, isLoading } = usePlayGame();

  const [result, setResult] = useState<PlayResponse | undefined>(undefined);
  const [error, setError] = useState<string | undefined>(undefined);
  const [isShuffling, setIsShuffling] = useState(false);

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

  return (
    <div className="game-container">
      <GameChoices
        choices={choices}
        disabled={isLoading || isShuffling}
        onPick={(choice: Choice) => handlePlay(choice.id)}
      />
      <RandomChoicePicker
        choices={choices}
        onPick={(choice) => handlePlay(choice.id)}
        isShuffling={isShuffling}
        setIsShuffling={setIsShuffling}
      />
      {isLoading && <ResultsLoader />}
      {error && <ErrorMessage message={error} />}
      {result && !isLoading && !isShuffling && (
        <GameResults result={result} choices={choices} />
      )}
    </div>
  );
};
