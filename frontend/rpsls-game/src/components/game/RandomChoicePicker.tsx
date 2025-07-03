import { Dispatch, SetStateAction, useState } from 'react';
import { Choice } from '../../models';
import { useGetRandomChoiceChoices } from '../../hooks';
import './RandomChoicePicker.css';

interface RandomChoicePickerProps {
  choices: Choice[];
  onPick: (choice: Choice) => void;
  isShuffling: boolean;
  setIsShuffling: Dispatch<SetStateAction<boolean>>;
}

export const RandomChoicePicker = ({
  choices,
  onPick,
  isShuffling,
  setIsShuffling
}: RandomChoicePickerProps) => {
  const { choice: randomChoice, refetch: refetchRandomChoice } =
    useGetRandomChoiceChoices();

  const [currentChoice, setCurrentChoice] = useState<Choice | undefined>(
    undefined
  );

  const handlePick = () => {
    if (isShuffling || choices.length === 0) return;

    setIsShuffling(true);

    let shuffleIndex = 0;
    const shuffleInterval = setInterval(() => {
      setCurrentChoice(choices[shuffleIndex % choices.length]);
      shuffleIndex++;
    }, 100);

    setTimeout(() => {
      clearInterval(shuffleInterval);
      setCurrentChoice(randomChoice);
      if (randomChoice) onPick(randomChoice);
      setIsShuffling(false);
      refetchRandomChoice();
    }, 2000);
  };

  return (
    <div className="picker-container">
      <h3>Can't decide?</h3>
      <button
        className="shuffle-btn"
        onClick={handlePick}
        disabled={isShuffling}
      >
        Sheldon Says...
      </button>
      <div className="choice-display">
        {currentChoice && (
          <div
            className={`choice-card ${isShuffling ? 'shuffling' : 'selected'}`}
          >
            {currentChoice.name}
          </div>
        )}
      </div>
    </div>
  );
};
