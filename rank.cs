        public static void matchItems(List<HighScore> list)
        {
            HighScore parent = new HighScore();
            int maxrank = 0;
            foreach (HighScore _item in list)
            {
                int rank = 0;
                if (_item.Points == parent.Points) //each match earns you a point
                    rank++;
                if (_item.Coins == parent.Coins)
                    rank++;
                if (_item.Category == parent.Category)
                    rank++;
                if (_item.Zone == parent.Zone)
                    rank++;
                if (rank > maxrank)
                    maxrank = rank; //keep track of the highest score so far
                _item.ranking = rank;
            }

            list = list.Where(p => p.ranking == maxrank).ToList();
        }
