﻿CREATE PARTITION SCHEME [PS_RunningQueries]
    AS PARTITION [PF_RunningQueries]
    ALL TO ([PRIMARY])