import { ScoreboardRow } from '../models';
import { useGetChoices } from './useGetChoices';
import { useGetLatestGameRounds } from './useGetLatestGameRounds';

interface GetScoreboardRowsHook {
  scoreboardRows: ScoreboardRow[];
  isLoading?: boolean;
}

export const useGetScoreboardRows = (): GetScoreboardRowsHook => {
  const { choices } = useGetChoices();
  const { gameRounds, isLoading } = useGetLatestGameRounds();

  const getChoiceName = (id: number) => {
    return choices.find((choice) => choice.id === id)?.name || 'Unknown';
  };

  const resultMap: Record<number, string> = {
    0: 'WIN',
    1: 'TIE',
    2: 'LOSE'
  };

  const scoreboardRows = (gameRounds ?? []).map(
    (round) =>
      new ScoreboardRow(
        getChoiceName(round.playerChoiceId),
        getChoiceName(round.computerChoiceId),
        resultMap[round.outcome],
        new Date(round.playedAt)
      )
  );

  return { scoreboardRows, isLoading };
};
