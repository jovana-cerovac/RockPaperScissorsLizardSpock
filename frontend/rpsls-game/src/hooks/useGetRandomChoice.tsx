import { Choice } from '../models';
import { useGetRandomChoiceQuery } from '../services';

interface GetRandomChoiceHook {
  choice: Choice | undefined;
  isFetching?: boolean;
  refetch: () => void;
}

export const useGetRandomChoiceChoices = (): GetRandomChoiceHook => {
  const { data, isFetching, refetch } = useGetRandomChoiceQuery();

  return {
    choice: data,
    isFetching,
    refetch
  };
};
