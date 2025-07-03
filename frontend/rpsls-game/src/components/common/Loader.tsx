import './Common.css';

interface LoaderProps {
  message: string;
}

export const Loader = ({ message }: LoaderProps) => {
  return (
    <div className="loader" aria-label="Loader">
      {message}
    </div>
  );
};
