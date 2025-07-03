import { useCallback } from 'react';
import { usePlayRoundMutation } from '../services';
import { PlayRequest, PlayResponse } from '../models';

interface PlayGameHook {
  playGame: (
    playRequest: PlayRequest,
    onSuccess?: (playResponse: PlayResponse) => void,
    onFailure?: (errorMessage: string) => void
  ) => void;
  isLoading: boolean;
}

export const usePlayGame = (): PlayGameHook => {
  const [playRoundMutation, { isLoading }] = usePlayRoundMutation();

  const playGame = useCallback(
    async (
      playRequest: PlayRequest,
      onSuccess?: (playResponse: PlayResponse) => void,
      onFailure?: (errorMessage: string) => void
    ) => {
      await playRoundMutation(playRequest)
        .unwrap()
        .then((playResponse) => {
          onSuccess?.(playResponse);
        })
        .catch((_) => onFailure?.('Something went wrong! Try again.'));
    },
    [playRoundMutation]
  );

  return { playGame, isLoading };
};
