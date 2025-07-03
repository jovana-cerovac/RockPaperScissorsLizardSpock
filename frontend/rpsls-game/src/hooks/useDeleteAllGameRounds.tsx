import { useCallback } from 'react';
import { useDeleteAllRoundsMutation } from '../services';

interface DeleteAllGameRoundsHook {
  deleteAllGameRounds: (onSuccess?: () => void, onFailure?: () => void) => void;
}

export const useDeleteAllGameRounds = (): DeleteAllGameRoundsHook => {
  const [deleteAllRoundsMutation] = useDeleteAllRoundsMutation();

  const deleteAllGameRounds = useCallback(
    async (onSuccess?: () => void, onFailure?: () => void) => {
      await deleteAllRoundsMutation()
        .unwrap()
        .then(() => onSuccess?.())
        .catch(() => onFailure?.());
    },
    [deleteAllRoundsMutation]
  );

  return { deleteAllGameRounds };
};
