import { Box, IconButton, useTheme} from "@mui/material"
import { useContext } from "react";
import { ColorModeContext, tokens } from "../../theme";
import InputBase from "@mui/material";
import  LightModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";
import  DarkModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";
import  SearchModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";
import  ConfiguracionesModeOutlinedIcon from "@mui/icons-material/LightModeOutlined";


const Topbar = () => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const colorMode = useContext(ColorModeContext);

    return( <Box display = "flex" justifyContent = "space-between" p={2}>
    <Box display = "flex" backgroundColor = {colors.white[400]}
    borderRadius= "3px"
    >
    <InputBase sx = {{ml : 2, flex: 1}} placeholder = "Search"></InputBase>    
    <IconButton type = "button" sx = {{p:1}}>
        <SearchIcon></SearchIcon>
    </IconButton>
    </Box>
    
    <IconButton></IconButton>
    </Box>
    );
    };
    
    export default Topbar;