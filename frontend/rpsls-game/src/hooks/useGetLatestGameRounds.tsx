import { GameRound } from '../models';
import { useGetGameRoundsQuery } from '../services';

interface GetLatestGameRoundsHook {
  gameRounds: GameRound[];
  isLoading?: boolean;
}

export const useGetLatestGameRounds = (): GetLatestGameRoundsHook => {
  const { data, isLoading } = useGetGameRoundsQuery();

  return {
    gameRounds: data ?? [],
    isLoading
  };
};
