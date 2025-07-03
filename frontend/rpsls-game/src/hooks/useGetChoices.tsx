import { Choice } from '../models';
import { useGetAllChoicesQuery } from '../services';

interface GetChoicesHook {
  choices: Choice[];
  isFetching?: boolean;
}

export const useGetChoices = (): GetChoicesHook => {
  const { data, isFetching } = useGetAllChoicesQuery();

  return {
    choices: data ?? [],
    isFetching
  };
};
